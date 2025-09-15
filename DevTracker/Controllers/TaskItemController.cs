using DevTracker.Application.Interfaces;
using DevTracker.Application.Validators;
using DevTracker.Contracts.DTOs;
using DevTracker.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DevTracker.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class TaskItemController : ControllerBase
{
    private readonly ITaskItemService _taskItemService;
    private readonly CreateTaskItemRequestValidator _createRequestvalidator;
    private readonly UpdateTaskItemRequestValidator _updateRequestvalidator;

    public TaskItemController(ITaskItemService taskItemService,
        CreateTaskItemRequestValidator createRequestvalidator,
        UpdateTaskItemRequestValidator updateRequestvalidator)
    {
        _taskItemService = taskItemService;
        _createRequestvalidator = createRequestvalidator;
        _updateRequestvalidator = updateRequestvalidator;
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
        var validationResponse = _createRequestvalidator.Validate(createTaskItemRequest);

        if (!validationResponse.IsValid)
        {
            return BadRequest(validationResponse.Errors.ToString());
        }

        var response = await _taskItemService.CreateTaskItemAsync(createTaskItemRequest);

        if (response.Result != Result.Success)
        {
            return Conflict(response.ErrorMessage);
        }

        return Ok("You added a task!");
    }

    [HttpPut]
    [Route("UpdateStatus")]
    public async Task<IActionResult> UpdateTaksStatus([FromBody] UpdateTaskItemRequest updateTaskItemRequest)
    {
        var validationResponse = _updateRequestvalidator.Validate(updateTaskItemRequest);

        if (!validationResponse.IsValid)
        {
            return BadRequest(validationResponse.Errors.ToString());
        }

        await _taskItemService.UpdateTaskStatusAsync(updateTaskItemRequest);

        return Ok("You updated a task Status!");
    }

    [HttpDelete]
    [Route("DeleteTask")]
    public async Task<IActionResult> DeleteTask([FromQuery] long taskId)
    {
        if (taskId <= 0)
        {
            return BadRequest("Task Id not found!");
        }

        await _taskItemService.DeleteTaskItemAsync(taskId);
        return Ok("You deleted a task!");
    }
}
