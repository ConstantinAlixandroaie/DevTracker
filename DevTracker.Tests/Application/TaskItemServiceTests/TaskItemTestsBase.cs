using DevTracker.Application.Interfaces;
using DevTracker.Data.Services;
using DevTracker.Data.Validators;
using DevTracker.Domain.DTOs;
using DevTracker.Domain.IRepositories;
using NSubstitute;

namespace DevTracker.Tests.Application.TaskItemServiceTests;

public abstract class TaskItemTestsBase : IDisposable
{
    protected CreateTaskItemRequest CreateTaskItemRequest;
    protected int CallsToItaskItemRepository;
    protected ITaskItemRepository _taskItemRepository = Substitute.For<ITaskItemRepository>();
    protected static CreateTaskItemRequestValidator _createTaskItemRequestValidator = new();
    protected static UpdateTaskItemRequestValidator _updateTaskItemRequestValidator = new();
    protected ITaskItemService _sut;

    protected TaskItemTestsBase()
    {
        _sut = Substitute.For<TaskItemService>(_taskItemRepository, _createTaskItemRequestValidator, _updateTaskItemRequestValidator);

    }
    public void Dispose()
    {

    }
}
