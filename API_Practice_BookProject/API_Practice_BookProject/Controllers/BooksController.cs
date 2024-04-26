using API_Practice_BookProject.Models;
using Microsoft.AspNetCore.Mvc;
using API_Practice_BookProject.DTO_s;
using API_Practice_BookProject.Repository;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        
        public BooksController(IBookRepository bookRepository)
        {
                _bookRepository = bookRepository;
        }

       
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            try
            {
                var bookList = _bookRepository.GetAllBooks();
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
                var book = _bookRepository.GetBookById(id);
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
                var book = _bookRepository.GetBookByAuthor(Author);
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
                var rentedBooks = _bookRepository.GetRentedBooks();
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

                Book book = _bookRepository.GetBookById(bookId);

                if (book == null)
                {
                    return NotFound("Book object does not exist");
                }

                _bookRepository.UpdateBook(bookId, bookRequest);

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

                _bookRepository.AddBook(bookRequest);

                var newBook = _bookRepository.GetBookByAuthor(bookRequest.Author);
                if (newBook == null) 
                {
                    return NotFound("Failed to retrieve the newly created book");
                }

                return CreatedAtAction(nameof(GetBook), new { id = newBook.BookId }, newBook);
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
                _bookRepository.DeleteBook(id);
                return NoContent();

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }


    }
}