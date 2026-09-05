namespace MovieApi.Services;

public class ServiceManager : IServiceManager
{
    public IMoviesService MoviesService { get; }

    public ServiceManager(IMoviesService moviesService)
    {
        MoviesService = moviesService;
    }
}
