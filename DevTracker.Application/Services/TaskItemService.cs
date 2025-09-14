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

    public async Task<CreateTaskItemResponse> CreateTaskItemAsync(CreateTaskItemRequest createTaskItemRequest)
    {
        return await _taskItemRepo.CreateTaskItemAsync(createTaskItemRequest.TaskItemTitle);
    }

    public async Task<DeleteTaskItemResponse> DeleteTaskItemAsync(long taskItemId)
    {
        return await _taskItemRepo.DeleteTaskItemAsync(taskItemId);
    }

    public async Task<IEnumerable<TaskItem>> GetTaskItemsAsync()
    {
        return await _taskItemRepo.GetTaskItemsAsync();
    }

    public async Task<UpdateTaskItemResponse> UpdateTaskStatusAsync(UpdateTaskItemRequest request)
    {
       return await _taskItemRepo.UpdateTaskItemStatusAsync(request.TaskId, request.Status);
    }
}
