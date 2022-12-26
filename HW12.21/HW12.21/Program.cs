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

            var data = JsonConvert.DeserializeObject<Data>(json);

            var charactersResult = data.Characters.OrderBy(c => c.Episode.Length);

            string resultJson = JsonConvert.SerializeObject(charactersResult);

            await File.WriteAllTextAsync("result.json", resultJson);

            Console.WriteLine(resultJson);


            Console.WriteLine("complete");
        }
    }
}