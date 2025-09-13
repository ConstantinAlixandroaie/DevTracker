using DevTracker.Domain.Enums;
using DevTracker.Domain.Models;

namespace DevTracker.Domain.IRepositories;

public interface ITaskItemRepository
{
    Task CreateTaskItemAsync(string taskItemTitle);
    Task DeleteTaskItemAsync(Guid taskItemId);
    Task UpdateTaskItemStatusAsync(Guid taskItemId,Status status);
    Task<List<TaskItem>> GetTaskItemsAsync();
}
