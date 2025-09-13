using DevTracker.Domain.Enums;

namespace DevTracker.Application.Services;

public interface ITaskItemService
{
    public Task<bool> CreateTaskItemAsync(string title);
    public Task DeleteTaskItemAsync(Guid taskItemId);
    public Task UpdateTaskStatusAsync(Status status);
}
