using DevTracker.Application.Services;
using DevTracker.Data.Validators;
using DevTracker.Domain.DTOs;
using DevTracker.Domain.Enums;
using DevTracker.Domain.IRepositories;
using DevTracker.Domain.Models;

namespace DevTracker.Data.Services;

public class TaskItemService : ITaskItemService
{
    private readonly ITaskItemRepository _taskItemRepo;
    private readonly CreateTaskItemRequestValidator _validator;

    public TaskItemService(ITaskItemRepository taskItemRepo, CreateTaskItemRequestValidator validator)
    {
        _taskItemRepo = taskItemRepo;
        _validator = validator;
    }

    public async Task CreateTaskItemAsync(CreateTaskItemRequest createTaskItemRequest)
    {
        var response =_validator.Validate(createTaskItemRequest);

        if (response.IsValid)
        {
            await _taskItemRepo.CreateTaskItemAsync(createTaskItemRequest.TaskItemTitle);
        }
    }

    public async Task DeleteTaskItemAsync(Guid taskItemId)
    {
        await _taskItemRepo.DeleteTaskItemAsync(taskItemId);
    }

    public async Task<List<TaskItem>> GetTaskItemsAsync()
    {
        return await _taskItemRepo.GetTaskItemsAsync();
    }

    public async Task UpdateTaskStatusAsync(Guid taskItemId, Status status)
    {
        await _taskItemRepo.UpdateTaskItemStatusAsync(taskItemId, status);
    }
}
