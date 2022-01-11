using ContentAPI.Data;
using ContentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentAPI.Controllers
{
    [ApiController]
    [Route("movie")]
    public class MovieController : ControllerBase
    {
        private MovieContext _context;

        public MovieController(MovieContext context)
        {
            _context = context;
        }

        [Route("addMovie")]
        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieModel movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getMoviesById), new { Id = movie.Id }, movie);
        }

        [Route("getMovies")]
        [HttpGet]
        public IEnumerable<MovieModel> GetMovies()
        {
            return _context.Movies;
        }

        [Route("getMovieById")]
        [HttpGet]
        public IActionResult getMoviesById(int id)
        {
            MovieModel movie =  _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if(movie != null)
            {
                return Ok(movie);
            }
            return NotFound();

        }
    }
}