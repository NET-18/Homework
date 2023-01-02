using leson_26._12._2022.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace leson_26._12._2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastService _weatherForecastService;
        private readonly SomeScopedService _someScopedService;
        private readonly SomeSingletoneService _someSingletoneService;

        public WeatherForecastController(WeatherForecastService weatherForecastService,
            SomeScopedService someScopedService,
            SomeSingletoneService someSingletoneService)
        {
            _weatherForecastService = weatherForecastService;
            _someScopedService = someScopedService;
            _someSingletoneService = someSingletoneService;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<WeatherForecast>>> GetAllForecastAsync()
        {
            Console.WriteLine($"controller: {_someScopedService.Id}");
            return await _weatherForecastService.GetAllAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<WeatherForecast>> GetByIdAsync(int id)
        {
            return await _weatherForecastService.GetByIdAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> AddItemForecastAsync()
        {
            return await _weatherForecastService.AddtItemAsync();
        }
        [HttpPost("{id:int}")]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> RenovationByIdAsync(int id)
        {
            return await _weatherForecastService.RenovationByIdAsync(id);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> DeleteByIdAsync(int id)
        {
            return await _weatherForecastService.DeleteByIdAsync(id);
        }

    }
}
