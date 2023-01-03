using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastService _weatherForecastService;
        private readonly SomeScopedService _someScopedService;
        private readonly SomeSingleToneService _someSingletonService;

        public WeatherForecastController(WeatherForecastService weatherForecastService, SomeScopedService someScopedService, SomeSingleToneService someSingletonService)
        {
            _weatherForecastService = weatherForecastService;
            _someScopedService = someScopedService;
            _someSingletonService = someSingletonService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetAllForecastAsync()
        {
            Console.WriteLine("controller:{0}",_someScopedService.Id);

            return await _weatherForecastService.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<WeatherForecast>> GetById(int id, CancellationToken token)
        {
            return await _weatherForecastService.GetByIdAsync(id);
        }
        
        [HttpGet("new")]
        public async Task<ActionResult<WeatherForecast>> GetNew()
        {
            return await _weatherForecastService.GetAddAsync();
        }

        [HttpPost("delete/{id:int}")]
        public async Task DeleteById(int id, CancellationToken token)
        {
            await _weatherForecastService.DeleteByIdAsync(id);
        }

        [HttpGet("refresh/{id:int}")]
        public async Task<ActionResult<WeatherForecast>> GetRefresh(int id, int TempC, string summary)
        {
            return await _weatherForecastService.GetRefreshAsync(id, TempC, summary);
        }
    }
}
