using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice_API_Project.Models;

namespace Practice_API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        //IN MEMORY STORAGE FOR SIMPLICITY
        private static readonly List<ToDoItem> _toDoItems = new List<ToDoItem>();

        [HttpGet]

        public IActionResult<IEnumerable<ToDoItem>> Get() 
        {
            return Ok(_toDoItems);
        }

        [HttpGet("{Id}")]

        public IActionResult<ToDoItem> Get(int id) 
        { 
         var todoItem = _toDoItems.FirstOrDefault(x => x.Id == id);
            if (todoItem == null) 
            {
                return NotFound();
            }
            return Ok(todoItem);
        }

    }
}
