using DevTracker.Application.Interfaces;
using DevTracker.Application.Services;
using DevTracker.Contracts.Requests;
using DevTracker.Data.Repositories.Interfaces;
using NSubstitute;

namespace DevTracker.Tests.Application.TaskItemServiceTests;

public abstract class TaskItemTestsBase : IDisposable
{
    protected CreateTaskItemRequest? CreateTaskItemRequest;
    protected int CallsToItaskItemRepository;
    protected ITaskItemRepository _taskItemRepository = Substitute.For<ITaskItemRepository>();
    protected ITaskItemService _sut;

    protected TaskItemTestsBase()
    {
        _sut = Substitute.For<TaskItemService>(_taskItemRepository);

    }
    public void Dispose()
    {

    }
}
