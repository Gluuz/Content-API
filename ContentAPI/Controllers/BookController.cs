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
        public static int Id;

        public static List<BookModel> books = new List<BookModel>();

        public BookController()
        {
        }

        [Route("addBook")]
        [HttpPost]
        public IActionResult AddBook([FromBody] BookModel book)
        {
            book.Id= Id++;
            books.Add(book);
            return CreatedAtAction(nameof(getBookById), new { Id = book.Id }, book);
        }

        [Route("getBooks")]
        [HttpGet]
        public IActionResult getBooks()
        {
            return Ok(books);
        }

        [Route("getBookById")]
        [HttpGet]
        public IActionResult getBookById(int id)
        {
           BookModel book = books.FirstOrDefault(book => book.Id == id);
            if(book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }
      
    }
}
