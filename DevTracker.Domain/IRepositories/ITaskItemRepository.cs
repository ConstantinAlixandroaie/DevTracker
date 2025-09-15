using DevTracker.Domain.Common;
using DevTracker.Domain.Enums;
using DevTracker.Domain.Models;

namespace DevTracker.Domain.IRepositories;

public interface ITaskItemRepository
{
    Task<Result<TaskItem>> CreateTaskItemAsync(string taskItemTitle);
    Task<Result<TaskItem>> DeleteTaskItemAsync(long taskItemId);
    Task<Result<TaskItem>> UpdateTaskItemStatusAsync(long taskItemId, Status status);
    Task<Result<IEnumerable<TaskItem>>> GetTaskItemsAsync();
}
