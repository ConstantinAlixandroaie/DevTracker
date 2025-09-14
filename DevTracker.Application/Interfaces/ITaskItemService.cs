using DevTracker.Domain.DTOs;
using DevTracker.Domain.Models;

namespace DevTracker.Application.Interfaces;

public interface ITaskItemService
{
    Task CreateTaskItemAsync(CreateTaskItemRequest createTaskItemRequest);
    Task<List<TaskItem>> GetTaskItemsAsync();
    Task DeleteTaskItemAsync(long taskItemId);
    Task UpdateTaskStatusAsync(UpdateTaskItemRequest request);
}
