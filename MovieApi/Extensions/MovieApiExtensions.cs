using Microsoft.EntityFrameworkCore;
using MovieApi.Data;

namespace MovieApi.Extensions;

public static class MovieApiExtensions
{
    public static async Task SeedDatabaseAsync(this IApplicationBuilder app)
    {
        // Database seeding is performed within a scoped service provider to ensure proper disposal of resources
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<MovieApiDbContext>();
            try 
            {
                // STOP! This is a destructive operation that will DELETE the database.
                // Use with caution in production environments!
                //
                // DELETE! The database and apply migrations to ensure a fresh start
                // await dbContext.Database.EnsureDeletedAsync();
                // await dbContext.Database.MigrateAsync();

                // Seed the database with initial data using the SeedData class
                await SeedData.InitAsync(dbContext); 
            }
            catch (Exception) 
            { 
                throw; 
            }
        }
    }
}