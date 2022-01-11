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
    [Route("movies")]
    public class MovieController : ControllerBase
    {
        private static int Id;

        private static List<MovieModel> movies = new List<MovieModel>();

        public MovieController()
        {

        }

        [Route("addMovie")]
        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieModel movie)
        {
            movie.Id = Id++;
            movies.Add(movie);
            return CreatedAtAction(nameof(getMoviesById), new { Id = movie.Id }, movie);
        }

        [Route("getMovies")]
        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(movies);
        }

        [Route("getMovieById")]
        [HttpGet]
        public IActionResult getMoviesById(int id)
        {
            MovieModel movie =  movies.FirstOrDefault(movie => movie.Id == id);
            if(movie != null)
            {
                return Ok(movie);
            }
            return NotFound();

        }
    }
}