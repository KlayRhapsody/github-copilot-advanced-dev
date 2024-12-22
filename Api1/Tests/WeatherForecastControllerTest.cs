#nullable disable
using Api1.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Api1.Tests;

[TestClass]
public class WeatherForecastControllerTest
{
    private WeatherForecastController _controller;
    private ILogger<WeatherForecastController> _logger;

    [TestInitialize]
    public void Setup()
    {
        _logger = new LoggerFactory().CreateLogger<WeatherForecastController>();
        _controller = new WeatherForecastController(_logger);
    }

    [TestMethod]
    public void Get_ReturnsWeatherForecastsWithValidTemperature()
    {
        // Act
        var result = _controller.Get();

        // Assert
        foreach (var forecast in result)
        {
            Assert.IsTrue(forecast.TemperatureC >= -20 && forecast.TemperatureC <= 55);
        }
    }

    [TestMethod]
    public void Get_ReturnsWeatherForecastsWithValidSummary()
    {
        // Act
        var result = _controller.Get();

        // Assert
        foreach (var forecast in result)
        {
            Assert.IsTrue(WeatherForecastController.Summaries.Contains(forecast.Summary));
        }
    }

    [TestMethod]
    public void Post_AddsNewWeatherForecast()
    {
        // Arrange
        var newForecast = new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(6)),
            TemperatureC = 25,
            Summary = "Warm"
        };

        // Act
        var result = _controller.Post(newForecast);

        // Assert
        Assert.IsInstanceOfType(result, typeof(OkResult));
        var forecasts = _controller.Get();
        Assert.IsTrue(forecasts.Any(f => f.Date == newForecast.Date));
    }

    [TestMethod]
    public void Delete_RemovesWeatherForecast()
    {
        // Arrange
        var dateToDelete = DateOnly.FromDateTime(DateTime.Now.AddDays(1));

        // Act
        var result = _controller.Delete(dateToDelete);

        // Assert
        Assert.IsInstanceOfType(result, typeof(OkResult));
        var forecasts = _controller.Get();
        Assert.IsFalse(forecasts.Any(f => f.Date == dateToDelete));
    }
}