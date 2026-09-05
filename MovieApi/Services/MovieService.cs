using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Models;
using MovieApi.Mapping;


namespace MovieApi.Services;

public class MovieService : IMoviesService
{
    private readonly MovieApiDbContext _dbContext;
    private readonly IMapper _mapper;

    public MovieService(MovieApiDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieDTO>> GetAllMovies()
    {
        var movies = await _dbContext.Movies.ToListAsync();
        return _mapper.MoviesToDTO(movies);
    }

    public async Task<MovieDTO> GetOneMovie(int id)
    {
        var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
        if (movie == null) return null!;
        return _mapper.MovieToDTO(movie);
    }

    public async Task<MovieDTO> CreateMovie(NewMovieDTO newMovieDTO)
    {
        var movie = _mapper.CreateMovieFromDTO(newMovieDTO);
        _dbContext.Movies.Add(movie);
        await _dbContext.SaveChangesAsync();
        return _mapper.MovieToDTO(movie);
    }
}
