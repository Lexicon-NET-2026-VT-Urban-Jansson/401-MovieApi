using MovieApi.Models;
using Riok.Mapperly.Abstractions;

namespace MovieApi.Controllers;

[Mapper]
public static partial class MapperlyMapper
{
    public static partial MovieDTO MovieToDTO(this Movie movie);
    public static partial IEnumerable<MovieDTO> MapperlyMoviesToDTO(this IEnumerable<Movie> movies);
    public static partial Movie MapperlyCreateMovieFromDTO(this NewMovieDTO newMovieDTO);
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