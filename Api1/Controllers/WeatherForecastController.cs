using Api1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    internal static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private static readonly List<WeatherForecast> Forecasts = new List<WeatherForecast>
    {
        new WeatherForecast { Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), TemperatureC = 20, Summary = "Mild" },
        new WeatherForecast { Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)), TemperatureC = 25, Summary = "Warm" },
        new WeatherForecast { Date = DateOnly.FromDateTime(DateTime.Now.AddDays(3)), TemperatureC = 30, Summary = "Hot" },
        new WeatherForecast { Date = DateOnly.FromDateTime(DateTime.Now.AddDays(4)), TemperatureC = 35, Summary = "Sweltering" },
        new WeatherForecast { Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)), TemperatureC = 40, Summary = "Scorching" }
    };

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecastDto> Get()
    {
        return Forecasts.Select(f => new WeatherForecastDto
        {
            Date = f.Date,
            TemperatureC = f.TemperatureC,
            Summary = f.Summary
        });
    }

    [HttpPost(Name = "PostWeatherForecast")]
    public IActionResult Post(WeatherForecastDto forecastDto)
    {
        var forecast = new WeatherForecast
        {
            Date = forecastDto.Date,
            TemperatureC = forecastDto.TemperatureC,
            Summary = forecastDto.Summary
        };
        Forecasts.Add(forecast);
        return Ok();
    }

    // GET /WeatherForecast/2021-07-01
    [HttpDelete("{date}", Name = "DeleteWeatherForecast")]
    public IActionResult Delete(DateOnly date)
    {
        var forecastToRemove = Forecasts.FirstOrDefault(f => f.Date == date);
        if (forecastToRemove != null)
        {
            Forecasts.Remove(forecastToRemove);
            return Ok();
        }
        return NotFound();
    }
}
