namespace MovieApi.Services;
public class ServiceManager(IMovieService movieService) : IServiceManager
{
    public IMovieService MovieService { get; } = movieService;
}
