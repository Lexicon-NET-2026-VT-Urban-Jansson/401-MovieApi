using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Extensions;
using MovieApi.Models;
using MovieApi.Services;


namespace MovieApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase //, IMoviesService
{
    private readonly MovieApiDbContext _dbContext;
    public MoviesController(MovieApiDbContext context)
    {
        _dbContext = context;
    }

    // GET: api/movies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieDTO>>> GetAllMovies()
    {
        var movies = await _dbContext.Movies.ToListAsync();
        return movies.MoviesToDTO().ToList();
    }



    // GET: api/movies/id
    [HttpGet("{id}")]
    public async Task<ActionResult<MapperlyMovieDTO>> GetOneMovie(int id)
    {
        // ToDo: Byt ut FindAsync mot FirstOrDefaultAsync och lägg till en Where-sats som filtrerar på id.
        var movie = await _dbContext.Movies.FindAsync(id);
        if (movie == null) return NotFound();

        //return movie.MovieToDTO();
        //return MapperlyMovieToDTO(movie);
        return movie.MapperlyMovieToDTO(); // <-- DET FUNKAR MED MAPPERLY!!! :D
    }


    // GET: api/movies/id
    //[HttpGet("{id}")]
    //public async Task<ActionResult<MovieDTO>> GetOneMovie(int id)
    //{
    //    // ToDo: Byt ut FindAsync mot FirstOrDefaultAsync och lägg till en Where-sats som filtrerar på id.
    //    var movie = await _dbContext.Movies.FindAsync(id);
    //    if (movie == null) return NotFound();

    //    return movie.MovieToDTO();
    //}





    // POST: api/movies
    [HttpPost]
    public async Task<ActionResult<MovieDTO>> CreateNewMovie(NewMovieDTO newMovieDTO)
    {
        var newMovie = newMovieDTO.CreateMovieFromDTO();
        _dbContext.Movies.Add(newMovie);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetOneMovie), new { id = newMovie.Id }, newMovie.MovieToDTO());
    }




    /* -----------------------------------------------------------------
        // PUT: api/movies/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int? id, Movie movie)
        {
            if (id != movie.Id) return BadRequest();

            _dbContext.Entry(movie).State = EntityState.Modified;

            try 
                { await _dbContext.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // DELETE: api/movies/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int? id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);

            if (movie == null) return NotFound();

            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // MovieExists is a private helper method
        private bool MovieExists(int? id)
        {
            return _dbContext.Movies.Any(e => e.Id == id);
        }
    ----------------------------------------------------------------- */

}
