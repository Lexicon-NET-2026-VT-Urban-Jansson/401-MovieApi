using MovieApi.Models;

namespace MovieApi.Mapping
{
    public interface IMapper
    {
        Movie CreateMovieFromDTO(NewMovieDTO newMovieDTO);
        IEnumerable<MovieDTO> MoviesToDTO(IEnumerable<Movie> movies);
        MovieDTO MovieToDTO(Movie movie);
    }
}