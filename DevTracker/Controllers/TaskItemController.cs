using DevTracker.API.Extensions;
using DevTracker.Application.Interfaces;
using DevTracker.Contracts;
using DevTracker.Contracts.Requests.TaskItems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevTracker.API.Controllers;

/// <summary>
/// Provides endpoints for Task item operations.
/// </summary>
[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class TaskItemController : ControllerBase
{
    private readonly ITaskItemService _taskItemService;

    public TaskItemController(ITaskItemService taskItemService)
    {
        _taskItemService = taskItemService;
    }

    /// <summary>
    /// Retrieves all task items.
    /// </summary>
    /// <returns> A response containing a collection of task items.
    /// </returns>
    [HttpGet]
    [Route("GetTasks")]
    public async Task<IActionResult> GetTasks()
    {
        var response = await _taskItemService.GetTaskItemsAsync();
        return Ok(response);
    }

    /// <summary>
    /// Adds a new task with the specified details.
    /// </summary>
    /// <param name="createTaskItemRequest">A request object containing
    /// task item details creation</param>
    /// <returns> An IActionResult that contains the succes state or failure of the action.
    /// </returns>
    [HttpPost]
    [Route("AddTask")]
    public async Task<IActionResult> AddTask([FromBody] CreateTaskItemRequest createTaskItemRequest)
    {
        var userId = User.GetUserId();
        
        if (userId is null)
        {
            return BadRequest();
        }

        createTaskItemRequest.UserId = (long)userId;

        var response = await _taskItemService.CreateTaskItemAsync(createTaskItemRequest);

        if (response.Result != Result.Success)
        {
            return Conflict(response.ErrorMessage);
        }

        return Ok("Task Created Succesfully!");
    }

    /// <summary>
    /// Updates an existing task status.
    /// </summary>
    /// <param name="updateTaskItemRequest">
    /// The request object containing the task identifier and status
    /// </param>
    /// <returns>An IActionResult that contains the succes or failure of the action.
    /// </returns>
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

    /// <summary>
    /// Deletes an existing task.
    /// </summary>
    /// <param name="taskId">The identifier of the task item to be deleted
    /// </param>
    /// <returns>An IActionResult that contains the succes or failure of the action.
    /// </returns>
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
