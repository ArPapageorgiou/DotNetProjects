using API_Practice_BookProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using API_Practice_BookProject.DTO_s;

using System.Security.Cryptography.X509Certificates;
using API_Practice_BookProject.Data;



namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly BookDbContext _bookDbContext;

        
        public BooksController(BookDbContext bookDbContext)
        {
                _bookDbContext = bookDbContext;
        }

       

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            try
            {

                var bookList = _bookDbContext.books.ToList();
                return Ok(bookList);

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

                var book = _bookDbContext.books.FirstOrDefault(book => book.BookId == id);

                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }


        [HttpGet("author/{Author}")]
        public IActionResult GetBookByAuthor(string Author)
        {
            try
            {
                var book = _bookDbContext.books.FirstOrDefault(book => book.Author == Author);
                return Ok(book);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("rented-books")]
        public ActionResult<IEnumerable<Book>> GetRentedBooks()
        {
            try
            {
                var rentedBooks = _bookDbContext.books.Where(book => book.isRented).ToList();

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


                Book book = _bookDbContext.books.FirstOrDefault(book => book.BookId == bookId);


                if (book == null)
                {
                    return BadRequest("Book object does not exist");
                }

                book.Author = bookRequest.Author;
                book.Description = bookRequest.Description;
                book.Title = bookRequest.Title;

                _bookDbContext.SaveChanges();


                return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }






        }

        [HttpPost("add")]

        public IActionResult addBook([FromBody] BookRequest bookRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid book data");
                }

                var book = new Book
                {
                    Title = bookRequest.Title,
                    Author = bookRequest.Author,
                    Description = bookRequest.Description
                };

                _bookDbContext.books.Add(book);
                _bookDbContext.SaveChanges();

                return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, book);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                var bookToDelete = _bookDbContext.books.FirstOrDefault(book => book.BookId == id);
                if (bookToDelete == null)
                {
                    return NotFound("Book not found!");
                }

                _bookDbContext.books.Remove(bookToDelete);
                _bookDbContext.SaveChanges();
                return NoContent();

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }


    }
}