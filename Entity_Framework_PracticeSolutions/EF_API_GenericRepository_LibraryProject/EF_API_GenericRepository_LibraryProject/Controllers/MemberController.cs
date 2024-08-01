
﻿using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;


namespace EF_API_GenericRepository_LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {

        private readonly IApplication _application;

        public MemberController(IApplication application)
        {
            _application = application;
        }

        [HttpGet("{id}")]
        public ActionResult GetMember(int id) 
        {
            try
            {
                var member = _application.GetMember(id);
                return Ok(member);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id) 
        {
            try
            {
                _application.DeleteMember(id);
                return Ok("Member Deleted!");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertNewMember(MemberRequest memberRequest) 
        {
            try
            {
                var member = new Member
                {
                    FirstName = memberRequest.FirstName,
                    LastName = memberRequest.LastName,
                    Phone = memberRequest.Phone,
                    Email = memberRequest.Email,
                    RentedBooks = 0
                };

                _application.InsertNewMember(member);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

    }
}
