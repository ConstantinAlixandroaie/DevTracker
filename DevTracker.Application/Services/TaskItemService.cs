using DevTracker.Application.Interfaces;
using DevTracker.Domain.DTOs;
using DevTracker.Domain.IRepositories;
using DevTracker.Domain.Models;

namespace DevTracker.Application.Services;

public class TaskItemService : ITaskItemService
{
    private readonly ITaskItemRepository _taskItemRepo;

    public TaskItemService(ITaskItemRepository taskItemRepo)
    {
        _taskItemRepo = taskItemRepo;
    }

    public async Task CreateTaskItemAsync(CreateTaskItemRequest createTaskItemRequest)
    {
        await _taskItemRepo.CreateTaskItemAsync(createTaskItemRequest.TaskItemTitle);
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
        await _taskItemRepo.UpdateTaskItemStatusAsync(request.TaskId, request.Status);
    }
}
