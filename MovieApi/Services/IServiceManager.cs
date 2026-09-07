namespace MovieApi.Services;
public interface IServiceManager
{
    IMovieService MovieService { get; }
}