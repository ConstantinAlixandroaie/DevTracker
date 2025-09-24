using DevTracker.Core;
using DevTracker.Data.Enums;
using DevTracker.Data.Models;

namespace DevTracker.Data.Repositories.Interfaces;

public interface ITaskItemRepository
{
    Task<Result<TaskItem>> CreateTaskItemAsync(string taskItemTitle);
    Task<Result<TaskItem>> DeleteTaskItemAsync(long taskItemId);
    Task<Result<TaskItem>> UpdateTaskItemStatusAsync(long taskItemId, Status status);
    Task<Result<IEnumerable<TaskItem>>> GetTaskItemsAsync(long boardId);
}
