using Infrastructure.Data;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

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


        [HttpPut("add-remove-bookcopy")]


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

        [HttpDelete ("delete-book")]

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

        [HttpDelete("delete-member")]

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

        [HttpGet]

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

        [HttpGet("get-book")]

        public IActionResult GetBook(int memberId) 
        {
            try
            {
                var book = _application.GetBook(memberId);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("get-member")]

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

    }
}
