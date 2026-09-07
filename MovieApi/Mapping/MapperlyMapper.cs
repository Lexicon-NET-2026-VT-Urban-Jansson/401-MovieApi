using MovieApi.Models;
using Riok.Mapperly.Abstractions;

namespace MovieApi.Mapping;
[Mapper]
public partial class MapperlyMapper : IMapper
{
    public partial IEnumerable<MovieDTO> MoviesToDTO(IEnumerable<Movie> movies);
    public partial MovieDTO MovieToDTO(Movie movie);
    public partial Movie CreateMovieFromDTO(NewMovieDTO newMovieDTO);
}

/* ----------------------------------------------------------------------------- *
 *  Example of how to use custom properties in Mapperly.                         *
 * ----------------------------------------------------------------------------- *
[Mapper]
public partial class MapperlyMapper : IMapper
{
    private partial MovieDTO MapperlyMovieToDTO(Movie movie);
    public MovieDTO MovieToDTO(Movie movie)
    {
        // Map custom properties just like you would if you were writing your own functions
        var movieDTO = MapperlyMovieToDTO(movie);
        movieDTO.Description = "PERMANENT DESCRIPTION";
        return movieDTO;
    }
}
*/