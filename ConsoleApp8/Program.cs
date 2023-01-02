using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace ConsoleApp8
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            
            var p = new Person();

            var json = await File.ReadAllTextAsync("generated.json");
            var people = JsonConvert.DeserializeObject<List<Person>>(json);

            people = people.OrderBy(GetAge).Where(person => person.Friends.Count > 3).ToList();

            var resultJson = JsonConvert.SerializeObject(people);
            Directory.CreateDirectory("files");
            await File.WriteAllTextAsync("files/result.json", resultJson);
        }

        private static int GetAge(Person person)
        {
            return person.Age;
        }
    }
}