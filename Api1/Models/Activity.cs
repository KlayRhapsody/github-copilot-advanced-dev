using System.ComponentModel.DataAnnotations;

namespace Api1.Models;

public class Activity
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    public DateTime ExhibitionDate { get; set; }

    [Required]
    public DateTime SaleStartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    [Required]
    public List<Session> Sessions { get; set; } = new List<Session>();
}
