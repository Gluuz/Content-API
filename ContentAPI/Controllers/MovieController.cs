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
        private static List<MovieModel> movies = new List<MovieModel>();
        public MovieController()
        {

        }

        [HttpPost]
        public void AddMovie([FromBody] MovieModel movie)
        {
            movies.Add(movie);
        }
    }
}