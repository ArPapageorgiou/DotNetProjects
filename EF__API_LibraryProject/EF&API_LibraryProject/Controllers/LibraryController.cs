using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using EF_API_LibraryProject.DTOs;

namespace EF_API_LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IApplication _application;

        public LibraryController(IApplication application)
        {
            _application = application;
        }

        [HttpPut("add-remove-bookcopy/{bookId}/{ChangeByNumber}")]

        public IActionResult AddRemoveBookCopy(int bookId, int ChangeByNumber) 
        {
            try
            {
                _application.AddRemoveBookCopy(bookId, ChangeByNumber);
                    return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete ("delete-book/{memberId}")]

        public IActionResult DeleteBook(int bookId) 
        {
            try
            {
                _application.DeleteBook(bookId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("delete-member/{memberId}")]

        public IActionResult DeleteMember(int memberId)
        {
            try
            {
                _application.DeleteMember(memberId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("get-all-books")]

        public ActionResult<IEnumerable<Book>> GetAllBooks() 
        {
            try
            {
                var bookList = _application.GetAllBooks();
                if (bookList != null)
                {
                    return Ok(bookList);
                }
                else 
                {
                    return Ok(new List<Book>());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("get-book/{bookId}")]

        public IActionResult GetBook(int bookId) 
        {
            try
            {
                var book = _application.GetBook(bookId);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("get-member/{memberId}")]

        public IActionResult GetMember(int memberId) 
        {
            try
            {
                var member = _application.GetMember(memberId);
                return Ok(member);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("get-transaction/{}")]

        [HttpPost("insert-member/{member}")]

        public IActionResult InsertNewMember([FromBody] MemberRequest memberRequest) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newMemberId = _application.InsertNewMember(memberRequest);
                    return CreatedAtAction(nameof(GetMember), new { memberId = newMemberId});
                }
                else 
                {
                    return BadRequest("Not all information was provided by the client");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPost("insert-book/{book}")]

        public IActionResult InsertBook([FromBody] BookRequest bookRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newBookId = _application.InsertNewBook(bookRequest);
                    return CreatedAtAction(nameof(GetMember), new { memberId = newBookId });
                }
                else
                {
                    return BadRequest("Not all information was provided by the client");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        public IActionResult RentBook(int bookId, int memberId) 
        {
            try
            {
                _application.RentBook(bookId, memberId);
                return CreatedAtAction(nameof())
            }
            catch (Exception ex)
            {
                return BadRequest("Not all information was provided by the client");
            }
        }
    }
}
