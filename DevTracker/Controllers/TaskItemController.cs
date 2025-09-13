using Microsoft.AspNetCore.Mvc;

namespace DevTracker.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class TaskItemController : ControllerBase
{
    [HttpGet]
    [Route("GetTasks")]
    public IActionResult GetTasks()
    {
        return Ok("You got tasks!");
    }

    [HttpPost]
    [Route("AddTask")]
    public IActionResult AddTask()
    {
        return Ok("You added a task!");
    }

    [HttpPut]
    [Route("UpdateStatus")]
    public IActionResult UpdateTaksStatus()
    {
        return Ok("You updated a task Status!");
    }
}
