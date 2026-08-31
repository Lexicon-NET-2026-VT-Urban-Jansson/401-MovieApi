using Bogus;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models;


namespace MovieApi.Data;

public class SeedData
{
    private static Faker? _faker;
    private const int NUMBER_OF_MOVIES = 10;

    public static async Task InitAsync(MovieApiDbContext context)
    {
        if (await context.Movies.AnyAsync()) return;

        // For swedish locale, use "sv" instead of "en". The Faker library supports multiple locales.
        //_faker = new Faker("sv");
        _faker = new Faker("en");

        IEnumerable<Movie> movies = GenerateMovies(NUMBER_OF_MOVIES);
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
                ReleaseYear = _faker.Date.Between(new DateTime(1950, 1, 1), new DateTime(2026, 08, 30)).Year,
                DurationMinutes = (int)_faker.Finance.Amount(min: 30, max: 180),
                Rating = (double)_faker.Finance.Amount(min: 0, max: 10, decimals: 1),
                Description = _faker.Commerce.ProductDescription(),
            }
            ;
            movies.Add(movie);
        }
        return movies;
    }
}
