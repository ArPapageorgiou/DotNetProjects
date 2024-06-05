
﻿using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;


namespace EF_API_GenericRepository_LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly IApplication _application;

        public TransactionController(IApplication application)
        {
            _application = application;
        }


        [HttpGet("{memberId}/{bookId}")]
        public IActionResult GetTransactions(int memberId, int bookId) 
        {
            try
            {
                var transaction = _application.GetTransactions(memberId, bookId);

                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public IActionResult RentBook([FromBody]TransactionRequest transactionRequest)
        {
            try
            {
                var transaction = new Transaction
                {
                    MemberId = transactionRequest.MemberId,
                    BookId = transactionRequest.BookId,
                };

                _application.RentBook(transaction.BookId, transaction.MemberId);

                return CreatedAtAction(nameof(GetTransactions), new { memberId = transaction.MemberId, bookId = transaction.BookId}, transaction);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        public IActionResult ReturnBook([FromBody]TransactionRequest transactionRequest) 
        {
            try
            {
                var transaction = new Transaction
                {
                    MemberId = transactionRequest.MemberId,
                    BookId = transactionRequest.BookId,
                };

                _application.ReturnBook(transaction.BookId, transaction.MemberId);
                return Ok("Transaction Complete!");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

    }
}
