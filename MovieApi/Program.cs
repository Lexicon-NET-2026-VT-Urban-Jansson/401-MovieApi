using Microsoft.EntityFrameworkCore;
using MovieApi.Controllers;
using MovieApi.Data;
using MovieApi.Extensions;
using MovieApi.Services;


//const bool DO_TEST_MAPPERLY = false;

// Create a builder for the application
var builder = WebApplication.CreateBuilder(args);

// Setup database connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<MovieApiDbContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


//#if DO_TEST_MAPPERLY
//builder.Services.AddScoped<IMoviesController, MoviesControllerMapperly>();
//#else
//builder.Services.AddScoped<IMoviesController, MoviesControllerCustom>();
//#endif

// Add service layer IMoviesService to the container
//builder.Services.AddServiceLayer();
builder.Services.AddScoped<IMoviesService, MoviesController>();

// Bulid application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Use Swagger middleware to generate and serve OpenAPI documentation
    app.MapOpenApi();

    // Seed the database with initial data
    await app.SeedDatabaseAsync();
}

// Use HTTPS redirection middleware to redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Use authorization middleware to enable authorization capabilities
app.UseAuthorization();

// Map controller routes to the application
app.MapControllers();

// Run the application  
app.Run();
