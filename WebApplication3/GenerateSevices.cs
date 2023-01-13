using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Xml.Linq;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3
{
    public class GenerateSevices
    {
        private readonly GenerateSevices _someScopedService;

       
        public async Task<Person> GetRandomPerson(int friends, int tags)
        {
            if (!File.Exists("generated.json"))
                File.Create("generated.json").Close();
            var json = await File.ReadAllTextAsync("generated.json");
            JsonConvert.DeserializeObject<List<WeatherForecast>>(json);
            var rand = new Random();
            int r = rand.Next(0, 10);
            var person = new Person();
            string[] namesWoman =
            {
                "Caroline",
                "Margarite",
                "Victoria",
                "Elisaveta",
                "Shlondra",
                "Potaskuha"
            };
            string[] namesMan =
            {
                "Mike",
                "Tony",
                "Andrew",
                "Gey",
                "Tomy",
                "Nikita"
            };
            string[] namespeople = namesMan.Union(namesWoman).ToArray();
            person.Guid = Guid.NewGuid();

            if (r % 2 == 0)
            {
                person.IsActive = true;
                person.Gender = "Male";
                person.Name = namesMan[rand.Next(0, namesMan.Length)];
            }
            else
            {
                person.IsActive = false;
                person.Gender = "Female";
                person.Name = namesWoman[rand.Next(0, namesWoman.Length)];
            }

            person.Balance = $"${rand.Next(0,999)},{rand.Next(99, 999)}.{rand.Next(0, 999)}";
            person.Age = rand.Next(0, 100);

            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var email = "";
            for (int i = 0; i < rand.Next(0,15); i++)
            {
                email = email + chars[rand.Next(0, chars.Length)];
            }
            email += "@mail.ru";
            person.Email = email;
            person.Phone = $"+{rand.Next(0, 7)} ({rand.Next(99, 999)}) {rand.Next(99, 999)}-{rand.Next(999, 9999)}";
            var lorem = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            person.About = lorem[rand.Next(0, 20)..rand.Next(0,lorem.Length)];

            string[] valueTags = { "occaecat", "adipisicing", "mollit", "cillum", "qui" , "ullamco", "fugiat" , "reprehenderit", "consequat", "nisi" };
            person.Tags = new List<string>();
            for (int i = 0; i < tags; i++)
            {
                person.Tags.Add(valueTags[rand.Next(0, valueTags.Length)]);
            }
            person.Friends = new List<Friend>();
            for (int i = 0; i < friends; i++)
            {
                person.Friends.Add(new Friend()
                {
                    Id =i,
                    Name = namespeople[rand.Next(0, namespeople.Length)]
                }) ;
            }

            var list = JsonConvert.DeserializeObject<List<Person>> (json);
            if (list == null)
            {
                list = new List<Person>();
            }
            list.Add(person);
            var jsonResult = JsonConvert.SerializeObject(list);
            await File.WriteAllTextAsync("generated.json", jsonResult);
            return JsonConvert.DeserializeObject<List<Person>>(jsonResult)
               .Last();
        }
    }
}
