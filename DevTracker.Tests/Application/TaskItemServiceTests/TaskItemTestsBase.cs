using DevTracker.Application.Services;
using DevTracker.Data.Services;
using DevTracker.Data.Validators;
using DevTracker.Domain.DTOs;
using DevTracker.Domain.IRepositories;
using DevTracker.Domain.Models;
using NSubstitute;
using System.ComponentModel.DataAnnotations;

namespace DevTracker.Tests.Application.TaskItemServiceTests;

public class TaskItemTestsBase : IDisposable
{
    protected ITaskItemService _sut;
    protected ITaskItemRepository _iTaskItemRepository = Substitute.For<ITaskItemRepository>();
    protected CreateTaskItemRequest _createTaskItemRequest;
    protected CreateTaskItemRequestValidator _validator  = new CreateTaskItemRequestValidator();
    protected TaskItemTestsBase()
    {
        _sut = Substitute.For<TaskItemService>(Substitute.For<ITaskItemRepository>(), _validator);
    }

    public void Dispose()
    {

    }

    protected void Setup(string taskItemTitle)
    {
        _createTaskItemRequest = new CreateTaskItemRequest
        {
            TaskItemTitle = taskItemTitle
        };

        _sut.GetTaskItemsAsync().Returns([new TaskItem { Title = taskItemTitle }]);
    }
}
