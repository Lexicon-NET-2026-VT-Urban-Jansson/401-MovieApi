using MovieApi.Controllers;
using MovieApi.Services;

namespace MovieApi.Extensions;

public static class ServiceExtensions
{
    public static void AddServiceLayer(this IServiceCollection services)
    {
        //services.AddScoped<IServiceManager, ServiceManager>();
        
        //services.AddScoped<IMoviesService, MoviesController>();
        //services.AddLazy<ICompanyService>();
    }
}
