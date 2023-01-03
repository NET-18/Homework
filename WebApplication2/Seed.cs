using Newtonsoft.Json;
using System.Collections.Generic;
using WebApplication2.Services;

namespace WebApplication2
{
    public static class Seed
    {
        public static async Task SeedForecasts()
        {
            if (File.Exists("data.json"))
            {
                return;
            }
            var list = new List<WeatherForecast>();

            for (int i = 0; i < 100; i++)
            {
                var temp = Random.Shared.Next(-15, 30);
                list.Add(new WeatherForecast()
                {
                    Id = i + 1,
                    Date = DateTime.Now,
                    Summary = temp < 5 ? "Cold" : "Norm",
                    TemperatureC = temp,
                }); ;
            }

            var json = JsonConvert.SerializeObject(list);
            await File.WriteAllTextAsync("data.json", json);
        }
        
    }
}
