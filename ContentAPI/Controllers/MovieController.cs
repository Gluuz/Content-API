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
        [Route("addMovies")]
        [HttpPost]
        public void AddMovie([FromBody] MovieModel movie)
        {
            movie.Id = Id++;
            movies.Add(movie);
        }
        [Route("getMovies")]
        [HttpGet]
        public IEnumerable<MovieModel> GetMovies()
        {
            return movies;
        }
    }
}