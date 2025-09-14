using DevTracker.Domain.DTOs;
using DevTracker.Domain.Models;

namespace DevTracker.Application.Interfaces;

public interface ITaskItemService
{
    Task<CreateTaskItemResponse> CreateTaskItemAsync(CreateTaskItemRequest createTaskItemRequest);
    Task<IEnumerable<TaskItem>> GetTaskItemsAsync();
    Task<DeleteTaskItemResponse> DeleteTaskItemAsync(long taskItemId);
    Task<UpdateTaskItemResponse> UpdateTaskStatusAsync(UpdateTaskItemRequest request);
}
