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

        [HttpPut("add-ramove-bookcopy")]

        public IActionResult AddRemoveBookCopy(int bookId, int ChangeByNumber) 
        {
            try
            {
                if (bookId != null)
                {
                    _application.AddRemoveBookCopy(bookId, ChangeByNumber);
                    return NoContent();
                }
                else 
                {
                    return BadRequest("Invalid Book Id");
                }
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
    }
}
