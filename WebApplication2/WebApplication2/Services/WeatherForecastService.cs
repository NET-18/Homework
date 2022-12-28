using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApplication2.Services
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
            return JsonConvert.DeserializeObject<List<WeatherForecast>>(json)
                .FirstOrDefault(f => f.Id == id);
        }

        public async Task AddItemAsync()
        {
            var json = await File.ReadAllTextAsync("data.json");
            var listWeatherForecast = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);

            var temp = Random.Shared.Next(-15, 30);

            listWeatherForecast.Add(new WeatherForecast()
            {
                Id = listWeatherForecast.Count + 1,
                Date = DateTime.Now,
                Summary = temp < 5 ? "Cold" : "Norm",
                TemperatureC = temp
            });

            var resultJson = JsonConvert.SerializeObject(listWeatherForecast);
            await File.WriteAllTextAsync("data.json", resultJson.ToString());
        }

        public async Task ChangeAsync(int id, int temperature)
        {
            var json = await File.ReadAllTextAsync("data.json");
            var listWeatherForecast = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);

            if (listWeatherForecast.Exists(w => w.Id == id))
            {
                var index = listWeatherForecast.FindIndex(w => w.Id == id);
                listWeatherForecast[index].TemperatureC = temperature;
                listWeatherForecast[index].Summary = temperature < 5 ? "Cold" : "Norm";
                var resultJson = JsonConvert.SerializeObject(listWeatherForecast);
                await File.WriteAllTextAsync("data.json", resultJson.ToString());
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var json = await File.ReadAllTextAsync("data.json");
            var listWeatherForecast = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);

            if (listWeatherForecast.Exists(w => w.Id == id))
            {
                var index = listWeatherForecast.FindIndex(w => w.Id == id);
                listWeatherForecast.RemoveAt(index);

                var resultJson = JsonConvert.SerializeObject(listWeatherForecast);
                await File.WriteAllTextAsync("data.json", resultJson.ToString());
            }
        }

        public async Task DeleteByTemperatureAsync(int temperature)
        {
            var json = await File.ReadAllTextAsync("data.json");
            var listWeatherForecast = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);

            if (listWeatherForecast.Exists(w => w.TemperatureC == temperature))
            {
                listWeatherForecast = listWeatherForecast.Where(w => w.TemperatureC != temperature).ToList();
                var resultJson = JsonConvert.SerializeObject(listWeatherForecast);
                await File.WriteAllTextAsync("data.json", resultJson.ToString());
            }
        }
    }
}
