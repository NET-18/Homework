using Newtonsoft.Json;

namespace TMS_Tvelvth_App
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var p = new Person();

            var json = await File.ReadAllTextAsync("generated.json");
            var people = JsonConvert.DeserializeObject<List<Person>>(json);

            //people = people.OrderBy(person => person.Age).Where(person => person.Friends.Count > 3).ToList();

            var resultJson = JsonConvert.SerializeObject(people);

            await File.WriteAllTextAsync("result.json", resultJson);
        }
    }
}