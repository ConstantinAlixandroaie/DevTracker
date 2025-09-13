using DevTracker.Application.Services;
using DevTracker.Domain.Enums;

namespace DevTracker.Data.Services;

public class TaskItemService : ITaskItemService
{
    public Task<bool> CreateTaskItemAsync(string title)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTaskItemAsync(Guid taskItemId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTaskStatusAsync(Status status)
    {
        throw new NotImplementedException();
    }
}
