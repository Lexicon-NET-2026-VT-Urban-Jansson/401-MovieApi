namespace MovieApi.Services
{
    public interface IServiceManager
    {
        IMoviesService MoviesService { get; }
    }
}
