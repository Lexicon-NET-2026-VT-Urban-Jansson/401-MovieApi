using System.ComponentModel.DataAnnotations;


namespace MovieApi.Models;

public class Movie
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Genre { get; set; } = string.Empty;
    [Required]
    public string Director { get; set; } = string.Empty;
    [Range(1950, 2026)]
    public int ReleaseYear { get; set; }
    [Range(30, 180)]
    public int DurationMinutes { get; set; }
    [Range(0, 10)]
    public double Rating { get; set; }
    public string? Description { get; set; }
}
