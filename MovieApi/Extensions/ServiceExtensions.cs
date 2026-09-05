using MovieApi.Controllers;
using MovieApi.Mapping;
using MovieApi.Services;

namespace MovieApi.Extensions;

public static class ServiceExtensions
{
    private static void AddMovieServices(this IServiceCollection services)
    {
        services.AddScoped<IMoviesService, MovieService>();
        services.AddScoped<IServiceManager, ServiceManager>();
    }

    private static void AddMovieMappers(this IServiceCollection services, IConfiguration config)
    {
        services.AddKeyedScoped<IMapper>("custom", (sp, _) => new CustomMapper());
        services.AddKeyedScoped<IMapper>("mapperly", (sp, _) => new MapperlyMapper());

        // Select the mapper implementation based on the configuration value
        var mapperKey = config["Mapper"];
        services.AddScoped<IMapper>(sp => sp.GetRequiredKeyedService<IMapper>(mapperKey));
    }

    //{    public static void AddServiceLayer(this IServiceCollection services)
    public static void AddServiceLayer(this IServiceCollection services, IConfiguration config)
    {
        AddMovieServices(services);
        AddMovieMappers(services, config);
    }
}
