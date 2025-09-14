using DevTracker.Domain.DTOs;
using DevTracker.Domain.Enums;
using DevTracker.Domain.Models;

namespace DevTracker.Domain.IRepositories;

public interface ITaskItemRepository
{
    Task<CreateTaskItemResponse> CreateTaskItemAsync(string taskItemTitle);
    Task<DeleteTaskItemResponse> DeleteTaskItemAsync(long taskItemId);
    Task<UpdateTaskItemResponse> UpdateTaskItemStatusAsync(long taskItemId, Status status);
    Task<IEnumerable<TaskItem>> GetTaskItemsAsync();
}
