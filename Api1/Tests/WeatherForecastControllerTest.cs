#nullable disable
using Api1.Controllers;
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
    public void Get_ReturnsFiveWeatherForecasts()
    {
        // Act
        var result = _controller.Get();

        // Assert
        Assert.AreEqual(5, result.Count());
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
}