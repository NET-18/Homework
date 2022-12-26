using System.Text;
using HomeWork_Serialization_And_Network;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

class Program
{
    public static async Task Main(string[] args)
    {
        var client = new HttpClient()
        {
            BaseAddress = new Uri("https://techcrunch.com/wp-json/wp/v2/posts?per_page=100&context=embed"),
        };

        var get = await client.GetStringAsync(client.BaseAddress);

        var serializable = JsonConvert.DeserializeObject<IEnumerable<WeatherInfo>>(get);

        serializable.Select(x => x.Date.Day > 21);

        StringBuilder result = new StringBuilder();

        foreach (var weatherInfo in serializable)
        {
            result.Append(JsonConvert.SerializeObject(weatherInfo) + '\n');
        }
        
        await File.WriteAllTextAsync("serilizable.json", result.ToString());

    }
}