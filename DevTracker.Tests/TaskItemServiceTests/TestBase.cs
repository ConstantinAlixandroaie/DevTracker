using DevTracker.Application.Interfaces;
using DevTracker.Application.Services;
using DevTracker.Contracts.Requests.TaskItems;
using DevTracker.Data.Repositories.Interfaces;
using NSubstitute;

namespace DevTracker.Application.Tests.TaskItemServiceTests;

public abstract class TestBase : IDisposable
{
    protected CreateTaskItemRequest? CreateTaskItemRequest = new();
    protected UpdateTaskItemRequest? _updateTaskItemRequest = new();
    protected string? ErrorMessage = "Error";
    protected ITaskItemRepository _taskItemRepository = Substitute.For<ITaskItemRepository>();
    protected ITaskItemService _sut;

    protected TestBase()
    {
        _sut = Substitute.For<TaskItemService>(_taskItemRepository);
    }

    public void Dispose()
    {

    }
}
