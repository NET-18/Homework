using Newtonsoft.Json;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/search.php?s=margarita"),
                Timeout = TimeSpan.FromSeconds(10),
            };

            var responce = await client.GetAsync("https://www.thecocktaildb.com/api/json/v1/1/search.php?s=margarita");
            await File.WriteAllTextAsync("file.json", await responce.Content.ReadAsStringAsync());

            var json = await File.ReadAllTextAsync("file.json");
            var margaritas = JsonConvert.DeserializeObject<Menu>(json);

            var list = new List<Drink>();
            foreach (var item in margaritas.Drinks)
            {
                list.Add(item);
                Console.WriteLine(item.IdDrink);
            }
            Console.WriteLine();
            var correctedList = list.Skip(2).Take(3).Reverse();

            foreach (var corrected in correctedList)
            {
                Console.WriteLine(corrected.IdDrink);
            }

            var correctedJson = JsonConvert.SerializeObject(correctedList); 
            await File.WriteAllTextAsync("corrected_file.json", correctedJson);
        }
    }
}