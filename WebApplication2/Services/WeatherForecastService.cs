using Newtonsoft.Json;

namespace WebApplication2.Services
{
    public class WeatherForecastService
    {
        private readonly SomeScopedService _someScopedService;

        public WeatherForecastService(SomeScopedService someScopedService)
        {
            _someScopedService = someScopedService;
        }

        public async Task<List<WeatherForecast>> GetAllAsync()
        {
            Console.WriteLine($"service: {_someScopedService.Id}");

            var json = await File.ReadAllTextAsync("data.json");
            return JsonConvert.DeserializeObject<List<WeatherForecast>>(json);
        }

        public async Task<WeatherForecast> GetByIdAsync(int id)
        {
            var json = await File.ReadAllTextAsync("data.Json");
            return JsonConvert.DeserializeObject<List<WeatherForecast>>(json)
               .FirstOrDefault(f => f.Id == id);
        }
        
        public async Task<WeatherForecast> GetRefreshAsync(int id, int TempC, string summary)
        {
            var json = await File.ReadAllTextAsync("data.Json");
            var list = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);

            list[id-1].TemperatureC = TempC;
            list[id-1].Summary = summary;

            var jsonResult = JsonConvert.SerializeObject(list);
            await File.WriteAllTextAsync("data.json", jsonResult);
            return JsonConvert.DeserializeObject<List<WeatherForecast>>(jsonResult)
               .FirstOrDefault(f => f.Id == id);
        }
        
        public async Task DeleteByIdAsync(int id)
        {
            var json = await File.ReadAllTextAsync("data.Json");
            var list = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);
            list.RemoveAt(id+1);
            var jsonResult = JsonConvert.SerializeObject(list);
            await File.WriteAllTextAsync("data.json", jsonResult);
        }

        public async Task<WeatherForecast> GetAddAsync()
        {
            var json = await File.ReadAllTextAsync("data.json");
            var list = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);
            var temp = Random.Shared.Next(-15, 30);
            list.Add(new WeatherForecast()
            {
                Id = list.Count + 1,
                Date = DateTime.Now,
                Summary = temp < 5 ? "Cold" : "Norm",
                TemperatureC = temp,
            });
            var jsonResult = JsonConvert.SerializeObject(list);
            await File.WriteAllTextAsync("data.json", jsonResult);
            return JsonConvert.DeserializeObject<List<WeatherForecast>>(jsonResult)
               .Last();
        }


    }
}
