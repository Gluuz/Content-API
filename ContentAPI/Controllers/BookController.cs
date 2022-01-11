using ContentAPI.Data;
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

        public BookController(BookContext context)
        {
            _context = context;
        }

        [Route("addBook")]
        [HttpPost]
        public IActionResult AddBook([FromBody] BookModel book)
        {
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

        [Route("refreshBook")]
        [HttpPut]
        public IActionResult refreshMovie(int id, [FromBody] BookModel newBook)
        {
            BookModel book = _context.Books.FirstOrDefault(book => book.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            book.Title = newBook.Title;
            book.Gender = newBook.Gender;
            book.Writer = newBook.Writer;
            book.Pages = newBook.Pages;
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
