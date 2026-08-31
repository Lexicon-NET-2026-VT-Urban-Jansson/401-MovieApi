using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models;
using MovieApi.Data;


namespace MovieApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly MovieApiDbContext _dbContext;
    public MoviesController(MovieApiDbContext context)
    {
        _dbContext = context;
    }

    // GET: api/movies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
    {
        return await _dbContext.Movies.ToListAsync();
    }

    // GET: api/movies/id
    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetOneMovie(int id)
    {
        var movie = await _dbContext.Movies.FindAsync(id);

        if (movie == null) return NotFound();

        return movie;
    }

    // PUT: api/movies/id
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(int? id, Movie movie)
    {
        if (id != movie.Id) return BadRequest();

        _dbContext.Entry(movie).State = EntityState.Modified;

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MovieExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/movies
    [HttpPost]
    public async Task<ActionResult<Movie>> PostNewMovie(Movie movie)
    {
        _dbContext.Movies.Add(movie);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction("GetOneMovie", new { id = movie.Id }, movie);
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

    private bool MovieExists(int? id)
    {
        return _dbContext.Movies.Any(e => e.Id == id);
    }
}
