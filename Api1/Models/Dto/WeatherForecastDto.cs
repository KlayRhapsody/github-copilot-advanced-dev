using System.ComponentModel.DataAnnotations;

namespace Api1.Controllers;

public class WeatherForecastDto
{
    [Required]
    public DateOnly Date { get; set; }

    [Required]
    [Range(-100, 100)]
    public int TemperatureC { get; set; }

    [StringLength(50)]
    public string? Summary { get; set; }
}