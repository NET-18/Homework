using Newtonsoft.Json;

namespace TMS_Thirteen_App
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var response = await client.GetAsync("https://dog.ceo/api/breeds/image/random");

            var json = await response.Content.ReadAsStringAsync();

            var jsonSerialize = JsonConvert.SerializeObject(json);

            await File.WriteAllTextAsync("path.json", jsonSerialize);
        }
    }
}