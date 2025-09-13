using DevTracker.Domain.DTOs;
using DevTracker.Domain.Enums;
using DevTracker.Domain.Models;

namespace DevTracker.Application.Services;

public interface ITaskItemService
{
    Task CreateTaskItemAsync(CreateTaskItemRequest createTaskItemRequest);
    Task<List<TaskItem>> GetTaskItemsAsync();
    Task DeleteTaskItemAsync(Guid taskItemId);
    Task UpdateTaskStatusAsync(Guid taskItemId, Status status);
}
