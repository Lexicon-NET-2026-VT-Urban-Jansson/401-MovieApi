using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
    
namespace MovieApi.Services;
public interface IMovieService
{
    Task<IEnumerable<MovieDTO>> ReadDTOs();
    Task<MovieDTO> ReadDTO(int id);
    Task<MovieDTO> WriteDTO(NewMovieDTO newMovieDTO);
}
