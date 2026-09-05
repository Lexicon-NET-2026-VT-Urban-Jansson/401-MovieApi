using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Models;
using MovieApi.Services;


namespace MovieApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController(IServiceManager serviceManager) : ControllerBase
{
    private readonly IServiceManager _serviceManager = serviceManager;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieDTO>>> GetAllMovies() 
        => Ok(await _serviceManager.MoviesService.GetAllMovies());

    [HttpGet("{id}")]
    public async Task<ActionResult<MovieDTO>> GetOneMovie(int id)
    {
        var dto = await _serviceManager.MoviesService.GetOneMovie(id);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<MovieDTO>> CreateMovie(NewMovieDTO newMovieDTO) 
        => Ok(await _serviceManager.MoviesService.CreateMovie(newMovieDTO));
    
    // Ska detta med??
    // return CreatedAtAction(nameof(GetOneMovie), new { id = movie.Id }, movie.MovieToDTO());



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
