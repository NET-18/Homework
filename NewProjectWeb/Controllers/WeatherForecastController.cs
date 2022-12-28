using Microsoft.AspNetCore.Mvc;
using NewProjectWeb.Services;

namespace NewProjectWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    // [HttpGet("test/{id:int}")]
    // public string TestConstraint(int id)
    // {
    //     return $"id: {id}";
    // }
    private readonly WeatherForecastService _weatherForecastService;

    public WeatherForecastController()
    {
        _weatherForecastService = new WeatherForecastService();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetAllForecastsAsync()
    {
        return await _weatherForecastService.GetAllAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<WeatherForecast>> GetById(int id)
    {
        return await _weatherForecastService.GetByIdAsync(id);
    }
    
    [HttpGet("/add")]
    public async Task AddWeather()
    {
        await _weatherForecastService.AddWeatherForecastAsync();
    }
    
    [HttpGet("/update/{id:int}/{temp:int}}")]
    public async Task UpdateWeather(int id, int temp, string summary)
    {
        await _weatherForecastService.UpdateAsync(id, temp, summary);
    }

    [HttpGet("/delete/temp/{temp:int}")]
    public async Task DeleteByTemperature(int temp)
    {
        await _weatherForecastService.DeleteWeatherByTemperatureAsync(temp);
    }
    
    [HttpGet("/delete/id/{id:int}")]
    public async Task DeleteById(int id)
    {
        await _weatherForecastService.DeleteWeatherByIdAsync(id);
    }
}
