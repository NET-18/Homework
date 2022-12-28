using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastService _weatherForecastService;

        public WeatherForecastController()
        {
            _weatherForecastService = new WeatherForecastService();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetAllForecastAsync()
        {
            return await _weatherForecastService.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<WeatherForecast>> GetByIdAsync(int id)
        {
            return await _weatherForecastService.GetByIdAsync(id);
        }

        [HttpGet("/add")]
        public async Task AddWeatherForecast()
        {
            await _weatherForecastService.AddItemAsync();
        }

        [HttpGet("change/{id:int}/{temperature:int}")]
        public async Task ChangeWeather(int id, int temperature)
        {
            await _weatherForecastService.ChangeAsync(id, temperature);
        }

        [HttpDelete("delete/id/{id:int}")]
        public async Task DeleteById(int id)
        {
            await _weatherForecastService.DeleteByIdAsync(id);
        }

        [HttpDelete("delete/temperature/{temperature:int}")]
        public async Task DeleteByTemperature(int temperature)
        {
            await _weatherForecastService.DeleteByTemperatureAsync(temperature);
        }
    }
}
