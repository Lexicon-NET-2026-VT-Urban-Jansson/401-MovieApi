using MovieApi.Controllers;
using MovieApi.Models;

namespace MovieApi.Mapping;

public class CustomMapper : IMapper
{
    public MovieDTO MovieToDTO(Movie movie)
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

    public IEnumerable<MovieDTO> MoviesToDTO(IEnumerable<Movie> movies)
    {
        //return movies.Select(m => m.MovieToDTO());
        return movies.ToList().Select(m => MovieToDTO(m));
    }

    public Movie CreateMovieFromDTO(NewMovieDTO newMovieDTO)
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
