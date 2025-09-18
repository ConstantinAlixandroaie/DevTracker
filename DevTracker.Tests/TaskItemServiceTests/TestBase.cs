using DevTracker.Application.Interfaces;
using DevTracker.Application.Services;
using DevTracker.Contracts.Requests.TaskItems;
using DevTracker.Data.Repositories.Interfaces;
using NSubstitute;

namespace DevTracker.Application.Tests.TaskItemServiceTests;

public abstract class TestBase : IDisposable
{
    protected CreateTaskItemRequest? CreateTaskItemRequest;
    protected int CallsToItaskItemRepository;
    protected int TaskId;
    protected string? ErrorMessage;
    protected ITaskItemRepository _taskItemRepository = Substitute.For<ITaskItemRepository>();
    protected ITaskItemService _sut;

    protected TestBase()
    {
        _sut = Substitute.For<TaskItemService>(_taskItemRepository);

    }

    public void Dispose()
    {

    }

    protected void Setup(string? taskItemTitle = null, string? errorMessage = null, int repoCalls = 1, int taskId = 1)
    {
        CreateTaskItemRequest = new CreateTaskItemRequest
        {
            TaskItemTitle = taskItemTitle
        };

        ErrorMessage = errorMessage;
        CallsToItaskItemRepository = repoCalls;
        TaskId = taskId;
    }
}
