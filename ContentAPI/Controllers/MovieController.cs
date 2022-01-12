using AutoMapper;
using ContentAPI.Data;
using ContentAPI.Data.Dtos;
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
        private IMapper _mapper;

        public MovieController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        [Route("addMovie")]
        [HttpPost]
        public IActionResult addMovie([FromBody] MovieDTO movieDTO)
        {
            MovieModel movie = _mapper.Map<MovieModel>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getMoviesById), new { Id = movie.Id }, movie);
        }

        [Route("getMovies")]
        [HttpGet]
        public IEnumerable<MovieModel> getMovies()
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

        [Route("updateMovie")]
        [HttpPut]
        public IActionResult úpdateMovie(int id, [FromBody]MovieDTO movieDTO)
        {
            MovieModel movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            _mapper.Map(movieDTO, movie);
            _context.SaveChanges();
            return NoContent();
        }

        [Route("deleteMovie")]
        [HttpDelete]
        public IActionResult deleteMovie(int id)
        {
            MovieModel movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            _context.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}