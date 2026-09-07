using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Models;
using MovieApi.Mapping;

namespace MovieApi.Services;
public class MovieService(MovieApiDbContext dbContext, IMapper mapper) : IMovieService
{
    private readonly MovieApiDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<MovieDTO>> ReadDTOs() => 
        _mapper.MoviesToDTO(await _dbContext.Movies.ToListAsync());

    public async Task<MovieDTO> ReadDTO(int id)
    {
        var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
        return movie is null ? null! : _mapper.MovieToDTO(movie);
    }

    public async Task<MovieDTO> WriteDTO(NewMovieDTO newMovieDTO)
    {
        var movie = _mapper.CreateMovieFromDTO(newMovieDTO);
        _dbContext.Movies.Add(movie);
        await _dbContext.SaveChangesAsync();
        return _mapper.MovieToDTO(movie);
    }
}