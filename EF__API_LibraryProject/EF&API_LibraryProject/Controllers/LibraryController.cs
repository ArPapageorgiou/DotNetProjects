using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using EF_API_LibraryProject.DTOs;
using Application.DTOs;

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

        [HttpDelete("delete-book/{memberId}")]

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


        [HttpPost("insert-member")]

        public IActionResult InsertNewMember([FromBody] MemberRequest memberRequest)
        {
            try
            {
                var member = new Member()
                {
                    FirstName = memberRequest.FirstName,
                    LastName = memberRequest.LastName,
                    Address = memberRequest.Address,
                    Phone = memberRequest.Phone,
                    Email = memberRequest.Email
                };

                if (ModelState.IsValid)
                {
                    _application.InsertNewMember(member);
                    return CreatedAtAction(nameof(GetMember), new { memberId = member.MemberId }, member);
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

        [HttpPost("insert-book")]

        public IActionResult InsertBook([FromBody] BookRequest bookRequest)
        {
            try
            {
                var book = new Book()
                {
                    Title = bookRequest.Title,
                    Genre = bookRequest.Genre,
                    Description = bookRequest.Description,
                    TotalCopies = bookRequest.TotalCopies,
                    AvailableCopies = bookRequest.TotalCopies
                };
                if (ModelState.IsValid)
                {
                    _application.InsertNewBook(book);
                    return CreatedAtAction(nameof(GetBook), new { bookId = book.BookId }, book);
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

        [HttpGet("get-transaction")]

        public IActionResult GetRentalTransaction(RentalTransaction rentalTransaction)
        {
            try
            {
                var transaction = _application.GetRentalTransaction(rentalTransaction);
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("rent-book")]
        public IActionResult RentBook(RentalTransactionRequest rentalTransaction) 
        {
            try
            {
                var transaction = new RentalTransaction()
                {
                    BookId = rentalTransaction.BookId,
                    MemberId = rentalTransaction.MemberId,
                    RentedAt = DateTime.Now
                    
                };

                _application.RentBook(rentalTransaction.BookId, rentalTransaction.MemberId);
                return CreatedAtAction(nameof(GetRentalTransaction), new {transactionId = transaction.RentalTransactionId}, transaction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("return-book")]

        public IActionResult ReturnBook(RentalTransaction rentalTransaction) 
        {
            try
            {
                _application.ReturnBook(rentalTransaction.BookId, rentalTransaction.MemberId);
                return Ok("Transaction complete");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
