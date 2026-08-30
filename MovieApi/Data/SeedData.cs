using Bogus;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models;


namespace MovieApi.Data;

public class SeedData
{
    private static Faker? _faker;

    public static async Task InitAsync(MovieApiDbContext context)
    {
        if (await context.Movies.AnyAsync()) return;

        _faker = new Faker("en");   // ("sv");

        IEnumerable<Movie> movies = GenerateMovies(10);
        await context.AddRangeAsync(movies);

        await context.SaveChangesAsync();
    }

    private static List<Movie> GenerateMovies(int numberOfMovies)
    {
        List<Movie> movies = [];

        for (int i = 0; i < numberOfMovies; i++)
        {
            Movie movie = new Movie()
            {
                Title = _faker!.Commerce.ProductName(),
                Genre = _faker.Music.Genre(),
                Director = _faker.Name.FullName(),
                ReleaseYear = _faker.Date.Between(new DateTime(1910, 1, 1), new DateTime(2026, 12, 31)).Year,
                DurationMinutes = _faker.Date.Timespan(maxSpan: TimeSpan.FromHours(3)).Minutes,
                Rating = (double)_faker.Finance.Amount(min: 0, max: 10, decimals: 1),
                Description = _faker.Commerce.ProductDescription(),
            }
            ;
            movies.Add(movie);
        }
        return movies;
    }
}
