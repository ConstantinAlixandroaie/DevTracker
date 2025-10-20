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
    [Route("GetTasks/{boardId}")]
    public async Task<IActionResult> GetTasksAsync(long boardId)
    {
        var response = await _taskItemService.GetTaskItemsAsync(boardId);
        if (response.Result == Result.Failure)
        {
            return NotFound();
        }

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
    public async Task<IActionResult> AddTaskAsync([FromBody] CreateTaskItemRequest createTaskItemRequest)
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

        return Ok(response.Result);
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
    public async Task<IActionResult> UpdateTaskAsync([FromBody] UpdateTaskItemRequest updateTaskItemRequest)
    {

        var response = await _taskItemService.UpdateTaskAsync(updateTaskItemRequest);

        if (response.Result == Result.Failure)
        {
            return BadRequest(response.ErrorMessage);
        }
        if (response.Result == Result.NotFound)
        {
            return NotFound(response.ErrorMessage);
        }
        if (response.Result == Result.Conflict)
        {
            return Conflict(response.ErrorMessage);
        }

        return Ok(response.Result);
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
    public async Task<IActionResult> DeleteTaskAsync([FromQuery] long taskId)
    {
        var response = await _taskItemService.DeleteTaskItemAsync(taskId);

        if (response.Result != Result.Success)
        {
            return BadRequest(response.ErrorMessage);
        }

        return Ok(response.Result);
    }
}
