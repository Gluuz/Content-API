using ContentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        public static List<MovieModel> movies = new List<MovieModel>();

        [HttpPost]
        public void AddMovies([FromBody]MovieModel movie)
        {
            movies.Add(movie);
            Console.WriteLine(movie.Title);
        }
    }
}
