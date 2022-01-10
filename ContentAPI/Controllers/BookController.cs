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
        public static List<BookModel> books = new List<BookModel>();

        [HttpPost]
        public void AddBook([FromBody] BookModel book)
        {
            books.Add(book);
            
        }
    }
}
