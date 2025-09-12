using Microsoft.AspNetCore.Mvc;

namespace DevTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTasks()
        {
            return Ok("You got tasks!");
        }

        [HttpPost]
        public IActionResult AddTask()
        {
            return Ok("You added a task!");
        }

        [HttpPut]
        public IActionResult UpdateTaksStatus()
        {
            return Ok("You updated a task Status!");
        }
    }
}
