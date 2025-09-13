using DevTracker.Application.Services;
using DevTracker.Data.Services;
using DevTracker.Data.Validators;
using DevTracker.Domain.DTOs;
using DevTracker.Domain.IRepositories;
using NSubstitute;

namespace DevTracker.Tests.Application.TaskItemServiceTests;

public abstract class TaskItemTestsBase : IDisposable
{
    protected CreateTaskItemRequest CreateTaskItemRequest;
    protected ITaskItemRepository _taskItemRepository = Substitute.For<ITaskItemRepository>();
    protected static CreateTaskItemRequestValidator _validator = new();
    protected ITaskItemService _sut;

    protected TaskItemTestsBase()
    {
        _sut = Substitute.For<TaskItemService>(_taskItemRepository, _validator);

    }
    public void Dispose()
    {

    }

    protected abstract void Setup(string title);
}
