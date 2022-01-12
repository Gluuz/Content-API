using AutoMapper;
using ContentAPI.Data;
using ContentAPI.Data.Dtos;
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
    public class BookController : ControllerBase
    {
        private BookContext _context;
        private IMapper _mapper;

        public BookController(BookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("addBook")]
        [HttpPost]
        public IActionResult AddBook([FromBody] BookDTO bookDTO)
        {
            BookModel book = _mapper.Map<BookModel>(bookDTO);
            _context.Books.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getBookById), new { Id = book.Id }, book);
        }

        [Route("getBooks")]
        [HttpGet]
        public IEnumerable<BookModel> getBooks()
        {
            return _context.Books;
        }

        [Route("getBookById")]
        [HttpGet]
        public IActionResult getBookById(int id)
        {
           BookModel book = _context.Books.FirstOrDefault(book => book.Id == id);
            if(book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }

        [Route("updateBook")]
        [HttpPut]
        public IActionResult updateBook(int id, [FromBody] BookDTO bookDTO)
        {
            BookModel book = _context.Books.FirstOrDefault(book => book.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            _mapper.Map(bookDTO, book);
            _context.SaveChanges();
            return NoContent();
        }
        
        [Route("deleteBook")]
        [HttpDelete]
        public IActionResult deleteBook(int id)
        {
            BookModel book = _context.Books.FirstOrDefault(book => book.Id == id);
            if(book == null)
            {
                return NotFound();
            }
            _context.Remove(book);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
