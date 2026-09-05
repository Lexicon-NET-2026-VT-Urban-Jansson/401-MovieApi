using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
    
namespace MovieApi.Services;

public interface IMoviesService
{
    Task<IEnumerable<MovieDTO>> GetAllMovies();
    Task<MovieDTO> GetOneMovie(int id);
    Task<MovieDTO> CreateMovie(NewMovieDTO newMovieDTO);
}
