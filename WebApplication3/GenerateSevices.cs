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

namespace WebApplication3
{
    public class GenerateSevices
    {
        private readonly GenerateSevices _someScopedService;

        public async Task<Person> GetRandomPersonName()
        {
            int randomNumber = Random.Shared.Next(0, 10);
            var person = new Person();
                person.Name="";
                person.Gender="";
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

            if (randomNumber % 2 == 0)
            {
                person.Gender = "Male";
                person.Name = namesMan[Random.Shared.Next(0, namesMan.Length)];
            }
            else
            {
                person.Gender = "Female";
                person.Name = namesWoman[Random.Shared.Next(0, namesWoman.Length)];
            }
            return person;
        }

        public async Task<Guid> GetRandomGuid()
        {
            var guid = Guid.NewGuid();
            return guid;
        }

        public async Task<string> GetRandomBalance()
        {
            int balanceInt = Random.Shared.Next(0, 99_999_999);
            string balance = "";
            if (balanceInt > 999_999)
            {
                int balance1part = balanceInt / 1000000;
                int balance2part = balanceInt / 1000 - balance1part * 1000;
                int balance3part = balanceInt - balance2part * 1000 - balance1part * 1000000;
                balance = $"{balance1part},{balance2part}.{balance3part}";
            }
            if (balanceInt >= 999 && balanceInt <= 999_999)
            {
                int balance2part = balanceInt / 1000;
                int balance3part = balanceInt - balance2part * 1000;
                balance = $"{balance2part}.{balance3part}";
            }
            if (balanceInt < 999)
            {
                balance = $"0.{balanceInt}";
            }

            return balance;
        }

        public async Task<int> GetRandomAge()
        {
            var person = await GetRandomPersonName();
            var Age = Random.Shared.Next(person.Name.Length, 100);
            return Age;
        }

        public async Task<string> GetRandomEmail()
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var email = "";

            for (int i = 0; i < Random.Shared.Next(0, 15); i++)
            {
                email = email + chars[Random.Shared.Next(0, chars.Length)];
            }
            email += "@";
            for (int i = 0; i < Random.Shared.Next(0, 10); i++)
            {
                email = email + chars[Random.Shared.Next(0, chars.Length)];
            }
            email += ".com";

            return email;
        }

        public async Task<string> GetRandomPhone()
        {
            int part1 = Random.Shared.Next(0, 7);
            int part2 = Random.Shared.Next(99, 999);
            int part3 = Random.Shared.Next(99, 999);
            int part4 = Random.Shared.Next(999, 9999);

            var phone = $"+{part1} ({part2}) {part3}-{part4}";
            return phone;
        }

        public async Task<string> GetRandomAbout()
        {
            var lorem = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            var start = Random.Shared.Next(0, lorem.Length);
            var about = lorem[start..Random.Shared.Next(start, lorem.Length)];

            return about;
        }
        public async Task<List<string>> GetRandomTags(int tags)
        {
            string[] valueTags = { "occaecat", "adipisicing", "mollit", "cillum", "qui", "ullamco", "fugiat", "reprehenderit", "consequat", "nisi" };
            var listTags = new List<string>();
            for (int i = 0; i < tags; i++)
            {
                listTags.Add(valueTags[Random.Shared.Next(0, valueTags.Length)]);
            }
            return listTags;
        }
        public async Task<List<Friend>> GetRandomFriends(int friends)
        {
            var listFriends = new List<Friend>();
            for (int i = 0; i < friends; i++)
            {
                var person = await GetRandomPersonName();
                listFriends.Add(new Friend()
                {
                    Id = i,
                    Name = person.Name
                });
            }
            return listFriends;
        }

    public async Task<Person> GetRandomPerson(int friends, int tags)
        {
            if (!File.Exists("generated.json"))
            {
                File.Create("generated.json").Close();
            }

            var json = await File.ReadAllTextAsync("generated.json");
            JsonConvert.DeserializeObject<List<Person>>(json);

            Person person = await GetRandomPersonName();

            person.Guid = await GetRandomGuid();

            person.Balance = await GetRandomBalance();

            person.Age = await GetRandomAge();

            person.Email = await GetRandomEmail();

            person.Phone = await GetRandomPhone();

            person.About = await GetRandomAbout();

            person.Tags = await GetRandomTags(tags);

            person.Friends= await GetRandomFriends(friends);

            var list = JsonConvert.DeserializeObject<List<Person>>(json);
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
