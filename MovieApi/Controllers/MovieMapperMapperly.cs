using MovieApi.Models;
using Riok.Mapperly.Abstractions;

namespace MovieApi.Controllers;

[Mapper]
public static partial class MapperlyMovieMapper
{
    public static partial MapperlyMovieDTO MapperlyMovieToDTO(this Movie movie);
    public static partial IEnumerable<MapperlyMovieDTO> MapperlyMoviesToDTO(this IEnumerable<Movie> movies);
    public static partial Movie CreateMovieFromMapperlyDTO(this NewMapperlyMovieDTO newMapperlyMovieDTO);
}

//public static IEnumerable<MovieDTO> MoviesToDTO(this IEnumerable<Movie> movies)
//public static partial List<MapperlyMovieDTO> MapperlyMoviesToDTO(List<Movie> movies);


/*
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