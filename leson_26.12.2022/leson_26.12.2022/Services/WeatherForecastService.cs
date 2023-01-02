using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;


namespace leson_26._12._2022.Services
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
            var json = await File.ReadAllTextAsync("data.json");
            return JsonConvert.DeserializeObject<List<WeatherForecast>>(json)
                .FirstOrDefault(f => f.Id == id);
        }
        public async Task<List<WeatherForecast>> AddtItemAsync()
        {
            var json = await File.ReadAllTextAsync("data.json");
            var list = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);

            var temp = Random.Shared.Next(-15, 15);

            list.Add(new WeatherForecast()
            {
                Id = list.Count + 1,
                Date = DateTime.Now,
                Summary = temp < 5 ? "Cold" : "Norm",
                TemperatureC = temp
            });

            var addJson = JsonConvert.SerializeObject(list);
            await File.WriteAllTextAsync("data.json", addJson);
            return list;

        }
        public async Task<List<WeatherForecast>> RenovationByIdAsync(int id)
        {
            var json = await File.ReadAllTextAsync("data.json");
            var list = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);

            if (list.Exists(x => x.Id == id))
            {
                var temp = Random.Shared.Next(-15, 15);
                var index = list.Where(x => x.Id == id).FirstOrDefault();
                index.TemperatureC = temp;
                index.Date = DateTime.Now;
            }

            var revJson = JsonConvert.SerializeObject(list);
            await File.WriteAllTextAsync("data.json", revJson);
            return list;

        }
        public async Task<List<WeatherForecast>> DeleteByIdAsync(int id)
        {
            var json = await File.ReadAllTextAsync("data.json");
            var list = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);

            WeatherForecast delItem = list.Where(x => x.Id == id).FirstOrDefault();

            if (delItem != null)
            {
                list.Remove(delItem);
            }

            var delJson = JsonConvert.SerializeObject(list);
            await File.WriteAllTextAsync("data.json", delJson);
            return list;
        }
    }
}
