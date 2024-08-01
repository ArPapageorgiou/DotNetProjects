
﻿using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata;


namespace EF_API_GenericRepository_LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IApplication _application;

        public BookController(IApplication application)
        {
            _application = application;
        }

        [HttpGet]
        public IActionResult GetAllBooks() 
        {
            try
            {
                var books = _application.GetAllBooks();
                return Ok(books);
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
                if (ModelState.IsValid)
                {
                    var book = _application.GetBook(id);
                    return Ok(book);
                }
                else
                {
                    return BadRequest(400);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertNewBook([FromBody] BookRequest bookRequest)
        {
            try
            {
                if (bookRequest == null)
                {
                    return BadRequest(400);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(400);
                }

                var book = new Book
                {
                    Title = bookRequest.Title,
                    Description = bookRequest.Description,
                    Genre = bookRequest.Genre,
                    TotalCopies = bookRequest.TotalCopies,
                    AvailableCopies = bookRequest.TotalCopies
                };

                _application.InsertNewBook(book);

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
                _application.DeleteBook(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }



        [HttpPatch("{id}/{changeByNumber}")]

        public IActionResult AddRemoveBookCopy(int id, int changeByNumber)
        {
            try
            {
                _application.AddRemoveBookCopy(id, changeByNumber);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        

    }
}
