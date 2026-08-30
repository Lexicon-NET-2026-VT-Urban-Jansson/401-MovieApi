using Microsoft.EntityFrameworkCore;
using MovieApi.Models;


namespace MovieApi.Data;

public class MovieApiDbContext(DbContextOptions<MovieApiDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; } = default!;
}
