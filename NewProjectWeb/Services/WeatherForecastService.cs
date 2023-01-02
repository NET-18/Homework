using System.Text;
using System.Text.Json.Nodes;
using Newtonsoft.Json;

namespace NewProjectWeb.Services
{
    public class WeatherForecastService
    {
        public async Task<List<WeatherForecast>> GetAllAsync()
        {
            var json = await File.ReadAllTextAsync("data.json");
            return JsonConvert.DeserializeObject<List<WeatherForecast>>(json);
        }
        
        public async Task<WeatherForecast> GetByIdAsync(int id)
        {
            var json = await File.ReadAllTextAsync("data.json");
            return JsonConvert.DeserializeObject<List<WeatherForecast>>(json).FirstOrDefault(f => f.Id == id);
        }

        public async Task AddWeatherForecastAsync()
        {
            var json = await File.ReadAllTextAsync("data.json");
            var list = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);

            var temp = Random.Shared.Next(-15, 30);
            list.Add(new WeatherForecast()
            {
                Id = list.Count + 1,
                Date = DateTime.Now,
                Summary = temp < 5 ? "Cold" : "Norm",
                TemperatureC = temp
            });
            
            var newJson = JsonConvert.SerializeObject(list);

            await File.WriteAllTextAsync("data.json", newJson.ToString());
        }

        public async Task UpdateAsync(int id, int temp, string summary)
        {
            var json = await File.ReadAllTextAsync("data.json");
            var list = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);

            if (!list.Exists(x => x.Id == id))
            {
                return;
            }
            
            var index = list.FindIndex(x => x.Id == id);
            list[index].TemperatureC = temp;
            list[index].Summary = summary;
            
            var newJson = JsonConvert.SerializeObject(list);

            await File.WriteAllTextAsync("data.json", newJson.ToString());
        }

        public async Task DeleteWeatherByTemperatureAsync(int temp)
        {
            var json = await File.ReadAllTextAsync("data.json");
            var list = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);

            if (!list.Exists(x => x.TemperatureC == temp))
            {
                return;
            }
            
            var index = list.FindIndex(x => x.TemperatureC == temp);
            list.RemoveAt(index);
            
            var newJson = JsonConvert.SerializeObject(list);

            await File.WriteAllTextAsync("data.json", newJson.ToString());
        }
        
        public async Task DeleteWeatherByIdAsync(int id)
        {
            var json = await File.ReadAllTextAsync("data.json");
            var list = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);

            if (!list.Exists(x => x.Id == id))
            {
                return;
            }
            
            var index = list.FindIndex(x => x.Id == id);
            list.RemoveAt(index);
            
            var newJson = JsonConvert.SerializeObject(list);

            await File.WriteAllTextAsync("data.json", newJson.ToString());
        }
    }
}