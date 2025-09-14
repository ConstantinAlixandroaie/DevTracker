using DevTracker.Application.Interfaces;
using DevTracker.Data.Validators;
using DevTracker.Domain.DTOs;
using DevTracker.Domain.IRepositories;
using DevTracker.Domain.Models;

namespace DevTracker.Data.Services;

public class TaskItemService : ITaskItemService
{
    private readonly ITaskItemRepository _taskItemRepo;
    private readonly CreateTaskItemRequestValidator _createRequestvalidator;
    private readonly UpdateTaskItemRequestValidator _updateRequestvalidator;

    public TaskItemService(ITaskItemRepository taskItemRepo, CreateTaskItemRequestValidator validator, UpdateTaskItemRequestValidator updateRequestvalidator)
    {
        _taskItemRepo = taskItemRepo;
        _createRequestvalidator = validator;
        _updateRequestvalidator = updateRequestvalidator;
    }

    public async Task CreateTaskItemAsync(CreateTaskItemRequest createTaskItemRequest)
    {
        var response = _createRequestvalidator.Validate(createTaskItemRequest);

        if (response.IsValid)
        {
            await _taskItemRepo.CreateTaskItemAsync(createTaskItemRequest.TaskItemTitle);
        }
    }

    public async Task DeleteTaskItemAsync(long taskItemId)
    {
        await _taskItemRepo.DeleteTaskItemAsync(taskItemId);
    }

    public async Task<List<TaskItem>> GetTaskItemsAsync()
    {
        return await _taskItemRepo.GetTaskItemsAsync();
    }

    public async Task UpdateTaskStatusAsync(UpdateTaskItemRequest request)
    {
        var response = _updateRequestvalidator.Validate(request);

        if (response.IsValid)
        {
            await _taskItemRepo.UpdateTaskItemStatusAsync(request.TaskId, request.Status);
        }
    }
}
