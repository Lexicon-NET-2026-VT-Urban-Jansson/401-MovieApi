using Microsoft.EntityFrameworkCore;
 
// Create a builder for the application
var builder = WebApplication.CreateBuilder(args);

// Setup database connection
var connectionString = builder.Configuration.GetConnectionString("MovieApiConnection") ?? throw new InvalidOperationException("Connection string 'MovieApiConnection' not found.");
builder.Services.AddDbContext<MovieApiContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Bulid application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Use HTTPS redirection middleware to redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Use authorization middleware to enable authorization capabilities
app.UseAuthorization();

// Map controller routes to the application
app.MapControllers();

// Run the application  
app.Run();
