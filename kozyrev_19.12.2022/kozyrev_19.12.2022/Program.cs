using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace kozyrev_19._12._2022
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var p = new Person();
            var json = await File.ReadAllTextAsync("generated.json");
            var people = JsonConvert.DeserializeObject<List<Person>>(json);

            people = people.OrderBy(person => person.Age).Where(person => person.Friends.Count > 3).ToList();
            var resultJson = JsonConvert.SerializeObject(people);
            Directory.CreateDirectory("file");
            await File.WriteAllTextAsync("file/result.json", resultJson);
        }
    }
}