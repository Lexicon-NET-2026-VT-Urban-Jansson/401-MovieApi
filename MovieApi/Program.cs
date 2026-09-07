using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Extensions;

// Create a builder for the application
var builder = WebApplication.CreateBuilder(args);

// Get the connection string from the configuration, or throw an exception if not found
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
// Setup database connection
builder.Services.AddDbContext<MovieApiDbContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger/OpenAPI services to the container for API documentation
builder.Services.AddSwaggerGen();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add service layer IMoviesService & IMapper to the container
builder.Services.AddServiceLayer(builder.Configuration);

// Bulid application
var app = builder.Build();


// *** DEVELOPMENT ONLY ***
//
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Use Swagger middleware to generate and serve OpenAPI documentation
    app.MapOpenApi();

    // Use Swagger UI middleware to provide a user interface for exploring the API
    app.UseSwaggerUI();
    app.UseSwagger();

    // Seed the database with initial data
    await app.SeedDatabaseAsync();
}


// Use HTTPS redirection middleware to redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Use routing middleware to route incoming requests to the appropriate endpoints
app.UseRouting();

// Use authorization middleware to enable authorization capabilities
app.UseAuthorization();

// Use endpoint routing middleware to map controller routes to the application
app.MapControllers();

// Run the application  
app.Run();