using MovieApi.Models;

namespace MovieApi.Extensions;

public static class MovieMapper
{
    public static MovieDTO MovieToDTO(this Movie movie)
    {
        return new MovieDTO
        {
            Id = movie.Id,
            Title = movie.Title,
            Genre = movie.Genre,
            Director = movie.Director,
            ReleaseYear = movie.ReleaseYear,
            DurationMinutes = movie.DurationMinutes,
            Rating = movie.Rating,
            Description = movie.Description
        };
    }

    public static IEnumerable<MovieDTO> MoviesToDTO(this IEnumerable<Movie> movies)
    {
        return movies.Select(m => m.MovieToDTO());
    }

    public static Movie CreateMovieFromDTO(this NewMovieDTO newMovieDTO)
    {
        return new Movie
        {
            // Id = newMovieDTO.Id,
            Title = newMovieDTO.Title,
            Genre = newMovieDTO.Genre,
            Director = newMovieDTO.Director,
            ReleaseYear = newMovieDTO.ReleaseYear,
            DurationMinutes = newMovieDTO.DurationMinutes,
            Rating = newMovieDTO.Rating,
            Description = newMovieDTO.Description
        };
    }
}
