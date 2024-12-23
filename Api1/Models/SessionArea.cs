using System.ComponentModel.DataAnnotations;

namespace Api1.Models;

public class SessionArea
{
    [Required]
    [StringLength(100)]
    public string AreaTitle { get; set; } = string.Empty;

    [Required]
    public SubArea[] SubAreas { get; set; } = Array.Empty<SubArea>();
}

public class SubArea
{
    [Required]
    [StringLength(100)]
    public string SubTitle { get; set; } = string.Empty;

    [Range(0, 10000)]
    public int RemainCount { get; set; }
}