using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace leson_26._12._2022
{
    public static class Seed
    {
        public static async Task SeedForecast()
        {
            if (File.Exists("data.json"))
            {
                return;
            }
            var list = new List<WeatherForecast>();

            for (int i = 0; i < 100; i++)
            {
                var temp = Random.Shared.Next(-15, 15);

                list.Add(new WeatherForecast()
                {
                    Id = i + 1,
                    Date = DateTime.Now,
                    Summary = temp < 5 ? "Cold":"Norm",
                    TemperatureC = temp
                });
            }

            var json = JsonConvert.SerializeObject(list);
            await File.WriteAllTextAsync("data.json", json);
        }
    }
}
