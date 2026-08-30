using Microsoft.EntityFrameworkCore;
using MovieApi.Data;

namespace MovieApi.Extensions;

public static class MovieApiExtensions
{
    public static async Task SeedDatabaseAsync(this IApplicationBuilder app)
    {
        // Data Seed - Bogus Faker
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<MovieApiDbContext>();
            try { await SeedData.InitAsync(context); }
            catch (Exception) { throw; }
        }
    }
}