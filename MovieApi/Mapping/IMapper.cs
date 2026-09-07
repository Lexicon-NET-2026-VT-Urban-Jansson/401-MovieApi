using MovieApi.Models;

namespace MovieApi.Mapping;
public interface IMapper
{
    IEnumerable<MovieDTO> MoviesToDTO(IEnumerable<Movie> movies);
    MovieDTO MovieToDTO(Movie movie);
    Movie CreateMovieFromDTO(NewMovieDTO newMovieDTO);
}