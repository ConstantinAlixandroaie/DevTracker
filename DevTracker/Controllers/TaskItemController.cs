using DevTracker.Application.Interfaces;
using DevTracker.Contracts;
using DevTracker.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DevTracker.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class TaskItemController : ControllerBase
{
    private readonly ITaskItemService _taskItemService;

    public TaskItemController(ITaskItemService taskItemService)
    {
        _taskItemService = taskItemService;
    }

    [HttpGet]
    [Route("GetTasks")]
    public async Task<IActionResult> GetTasks()
    {
        var response = await _taskItemService.GetTaskItemsAsync();
        return Ok(response);
    }

    [HttpPost]
    [Route("AddTask")]
    public async Task<IActionResult> AddTask([FromBody] CreateTaskItemRequest createTaskItemRequest)
    {
        var response = await _taskItemService.CreateTaskItemAsync(createTaskItemRequest);

        if (response.Result != Result.Success)
        {
            return Conflict(response.ErrorMessage);
        }

        return Ok("Task Created Succesfully!");
    }

    [HttpPut]
    [Route("UpdateStatus")]
    public async Task<IActionResult> UpdateTaskStatus([FromBody] UpdateTaskItemRequest updateTaskItemRequest)
    {

        var response = await _taskItemService.UpdateTaskStatusAsync(updateTaskItemRequest);

        if (response.Result == Result.Failure)
        {
            return BadRequest(response.ErrorMessage);
        }

        return Ok("Task Updated Succesfully!");
    }

    [HttpDelete]
    [Route("DeleteTask")]
    public async Task<IActionResult> DeleteTask([FromQuery] long taskId)
    {
        if (taskId <= 0)
        {
            return BadRequest("Task Id not found!");
        }

        var response = await _taskItemService.DeleteTaskItemAsync(taskId);

        if (response.Result != Result.Success)
        {
            return BadRequest(response.ErrorMessage);
        }

        return Ok("You deleted a task!");
    }
}
