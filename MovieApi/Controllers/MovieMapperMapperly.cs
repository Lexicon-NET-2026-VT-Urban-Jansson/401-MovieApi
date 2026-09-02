using MovieApi.Models;
using Riok.Mapperly.Abstractions;

namespace MovieApi.Controllers;

[Mapper]
public static partial class MapperlyMovieMapper
{
    public static partial MapperlyMovieDTO MapperlyMovieToDTO(this Movie movie);
    //public partial IEnumerable<MapperlyMovieDTO> MoviesToMapperlyMovieDTO(this IEnumerable<Movie movie>);
    //public partial Movie CreateMovieFromMapperlyDTO(NewMapperlyMovieDTO newMapperlyMovieDTO);
}