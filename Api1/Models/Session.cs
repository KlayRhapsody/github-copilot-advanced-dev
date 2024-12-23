using System.ComponentModel.DataAnnotations;

namespace Api1.Models;

public class Session
{
    [Required]
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [StringLength(200)]
    public string Location { get; set; } = string.Empty;
}
