using DevTracker.Domain.Enums;

namespace DevTracker.Application.Services
{
    public interface ITaskItemService
    {
        public Task<bool> CreateTaskItem(string title);
        public Task DeleteTaskItem(Guid taskItemId);
        public Task UpdateTaskStatus(Status status);
    }
}
