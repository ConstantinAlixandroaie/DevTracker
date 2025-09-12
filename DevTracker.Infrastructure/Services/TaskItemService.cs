using DevTracker.Application.Services;
using DevTracker.Domain.Enums;

namespace DevTracker.Infrastructure.Services
{
    public class TaskItemService : ITaskItemService
    {
        public Task<bool> CreateTaskItem(string title)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTaskItem(Guid taskItemId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTaskStatus(Status status)
        {
            throw new NotImplementedException();
        }
    }
}
