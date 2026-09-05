using MovieApi.Models;
using Riok.Mapperly.Abstractions;

namespace MovieApi.Mapping;

[Mapper]
public partial class MapperlyMapper //: IMapper
{
    public partial MovieDTO MovieToDTO(Movie movie);
    public partial IEnumerable<MovieDTO> MoviesToDTO(IEnumerable<Movie> movies);
    public partial Movie CreateMovieFromDTO(NewMovieDTO newMovieDTO);
}


/* ----------------------------------------------------------------------------- *
 *  Example of how to use custom properties in Mapperly.                         *
 * ----------------------------------------------------------------------------- *
[Mapper]
public static partial class CarMapper
{
    // Automatically map mappable properties
    private static partial CarDto AutoMapCarToDto(Car car);

    public static CarDto MapCarToDto(Car car)
    {
        var dto = AutoMapCarToDto(car);
        // Map custom properties just like you would if you were writing your own functions
        // [...]
        return dto;
    }
}
*/