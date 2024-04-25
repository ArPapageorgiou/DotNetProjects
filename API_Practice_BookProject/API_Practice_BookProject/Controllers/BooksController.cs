using API_Practice_BookProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using API_Practice_BookProject.DTO_s;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> _bookList = new List<Book>
        {
            new Book{BookId = 1, Title = "Dune", Author = "Frank Herbert", Description = "SS", isRented = true},
            new Book{BookId = 2, Title = "Harry Potter", Author = "Rowling", Description = "LGBT", isRented = false},
            new Book{BookId = 3, Title = "1984", Author = "Orwel", Description = "B", isRented = true},
            new Book{BookId = 4, Title = "War and Peace", Author = "Tolstoy", Description = "Russian", isRented = false}
        };

        
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            try
            {
                return Ok(_bookList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            try
            {
                var book = _bookList.FirstOrDefault(book => book.BookId == id);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("{rented/id}")]
        public ActionResult<IEnumerable<Book>> GetRentedBooks(bool isRented) 
        {
            try
            {
                var rentedBooks = _bookList.Where(book => book.isRented).ToList();  
                return Ok(rentedBooks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("update-book")]
        public IActionResult UpdateBook(int bookId, [FromBody] BookRequest bookRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not all information was provided by the client");
                }

                Book book = _bookList.FirstOrDefault(book => book.BookId == bookId);

                if (book == null)
                {
                    return BadRequest("Book object does not exist");
                }

                book.Author = bookRequest.Author;
                book.Description = bookRequest.Description;
                book.Title = bookRequest.Title;

                return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}