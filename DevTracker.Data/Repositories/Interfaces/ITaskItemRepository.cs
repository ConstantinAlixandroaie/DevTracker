using DevTracker.Core;
using DevTracker.Data.Models;
using DevTracker.Data.Records;

namespace DevTracker.Data.Repositories.Interfaces;

public interface ITaskItemRepository
{
    Task<Result<TaskItem>> CreateTaskItemAsync(string taskItemTitle);
    Task<Result<TaskItem>> DeleteTaskItemAsync(long taskItemId);
    Task<Result<TaskItem>> UpdateTaskItemAsync(UpdateTaskItem updateRequest);
    Task<Result<IEnumerable<TaskItem>>> GetTaskItemsAsync(long boardId);
}
