using API_LearnAndPractice_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace API_LearnAndPractice_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private static List<ToDoItem> _toDoItems = new List<ToDoItem>
        {
            //new ToDoItem {Id = 1, Title = "task 1", Completed = false},
            //new ToDoItem {Id = 2, Title = "task 2", Completed = true}
        };


        //If we dont want to specify the return type of this method so that it can remain
        //flexible we can use IActionResult. The IActionResult return type is appropriate
        //when multiple ActionResult return types are possible in an action
        
        [HttpGet]//this maps the method to the httpget request

        public IActionResult GetAll()
        {
            
            if (_toDoItems.Count() == 0) //so for example lets say we would like to do a proper check before we return data
            {
                return NotFound();//With this check this returns a Status404NotFound response.
                                  //It isIActionResult that allows this return type.
            }                     ////If there are at least one todoitems we would return a 200 ok status code.
                                  //HTTP status codes are standard response codes given by web servers.

            //var toDoItemDTOs = _toDoItems.Select(item => MapToDoItemDTO(item)).ToList();

            return Ok(_toDoItems);
        
        
        }

        //private ToDoItemDTO MapToDoItemDTO(ToDoItem item) 
        //{ 
        //return new ToDoItemDTO
        //{ 
        //id
        //}
        //}


    }
}
