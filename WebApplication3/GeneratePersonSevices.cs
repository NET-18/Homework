using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Xml.Linq;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using WebApplication3.Services;

namespace WebApplication3
{
    public class GeneratePersonSevices
    {
        private readonly GenerateGuidService _guidService;
        private readonly GenerateBalanceService _balanceService;
        private readonly GeneratePersonNameService _personNameService;
        private readonly GenerateAgeService _ageService;
        private readonly GenerateEmailService _emailService;
        private readonly GeneratePhoneService _phoneService;
        private readonly GenerateAboutService _aboutService;
        private readonly GenerateTagsService _tagsService;
        private readonly GenerateFriendService _friendService;

        public GeneratePersonSevices(GenerateGuidService guidService, GenerateBalanceService balanceService, GeneratePersonNameService personNameService, GenerateAgeService ageService, GenerateEmailService emailService, GeneratePhoneService phoneService, GenerateAboutService aboutService, GenerateTagsService tagsService, GenerateFriendService friendService)
        {
            _guidService = guidService;
            _balanceService = balanceService;
            _personNameService = personNameService;
            _ageService = ageService;
            _emailService = emailService;
            _phoneService = phoneService;
            _aboutService = aboutService;
            _tagsService = tagsService;
            _friendService = friendService;
        }

        public async Task<Person> GetRandomPerson(int friends, int tags)
        {
            if (!File.Exists("generated.json"))
            {
                File.Create("generated.json").Close();
            }

            var json = await File.ReadAllTextAsync("generated.json");
            JsonConvert.DeserializeObject<List<Person>>(json);

            Person person = await _personNameService.GetRandomPersonName();
            person.Guid = await _guidService.GetRandomGuid();
            person.Balance = await _balanceService.GetRandomBalance();
            person.Age = await _ageService.GetRandomAge();
            person.Email = await _emailService.GetRandomEmail();
            person.Phone = await _phoneService.GetRandomPhone();
            person.About = await _aboutService.GetRandomAbout();
            person.Tags = await _tagsService.GetRandomTags(tags);
            person.Friends = await _friendService.GetRandomFriends(friends);

            person.IsActive = false;
            if (Random.Shared.Next(0,1)==0)
            {
                person.IsActive= true;
            }
            
            var list = JsonConvert.DeserializeObject<List<Person>>(json);
            if (list == null)
            {
                list = new List<Person>();
            }

            Random rand  = new Random();
            double var = rand.NextDouble();

            list.Add(person);
            var jsonResult = JsonConvert.SerializeObject(list);
            await File.WriteAllTextAsync("generated.json", jsonResult);
            return JsonConvert.DeserializeObject<List<Person>>(jsonResult)
               .Last();
        }
    }
}
