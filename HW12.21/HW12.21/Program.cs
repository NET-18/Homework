using Newtonsoft.Json;
using System;
using System.Net.Http.Json;

namespace HW12._21
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("https://rickandmortyapi.com/api/"),
                Timeout = TimeSpan.FromSeconds(3)
            };

            var response = await client.GetAsync("character/");
            var json = await response.Content.ReadAsStringAsync();

            var characters = JsonConvert.DeserializeObject<List<Character>>(json);

            //var data = JsonConvert.DeserializeObject<string>(json);
            //data = data.OrderBy()

            //people = people.OrderBy(p => p.Age).Where(p => p.Friends.Count > 3).ToList();

            var charactersResult = characters.OrderBy(c => c.Status).ToList();

            string resultJson = JsonConvert.SerializeObject(characters);

            await File.WriteAllTextAsync("result.json", resultJson);

            Console.WriteLine(resultJson);


            Console.WriteLine("complete");
        }
    }

    public class Info
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
    }

    public class Data
    {
        public Info Info { get; set; }

        [JsonProperty("results")]
        public Character Characters { get; set; }
    }
}