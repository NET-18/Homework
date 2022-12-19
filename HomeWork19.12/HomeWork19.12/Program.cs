using Newtonsoft.Json;

namespace HomeWork19._12
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Person person = new Person();

            string json = await File.ReadAllTextAsync("generated.json");

            var people = JsonConvert.DeserializeObject<List<Person>>(json);

            people = people.OrderBy(p => p.Age).Where(p => p.Friends.Count > 3).ToList();

            string resultJson = JsonConvert.SerializeObject(people);

            Directory.CreateDirectory("files");
            await File.WriteAllTextAsync("files/result.json", resultJson);

            Console.WriteLine("complete");
        }
    }
}