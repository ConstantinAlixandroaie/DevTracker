using DevTracker.Domain.DTOs;
using DevTracker.Domain.Models;
using NSubstitute;

namespace DevTracker.Tests.Application.TaskItemServiceTests;

public class CreateTaskItemTests : TaskItemTestsBase
{
    [Fact]
    public async Task CreateTaskItem_WithEmptyString_ExpectExceptionThrown()
    {
        //Arrange
        Setup(taskItemTitle: "");

        //Act
        await _sut.CreateTaskItemAsync(CreateTaskItemRequest);

        //Assert
        Assert.False(_validator.Validate(CreateTaskItemRequest).IsValid);
        Assert.Empty(_taskItemRepository.ReceivedCalls());
    }

    [Fact]
    public async Task CreateTaskItem_WithNull_ExpectExceptionThrownAsync()
    {
        //Arrange
        Setup(taskItemTitle: null!);

        //Act
        await _sut.CreateTaskItemAsync(CreateTaskItemRequest);

        //Assert
        Assert.False(_validator.Validate(CreateTaskItemRequest).IsValid);
        Assert.Empty(_taskItemRepository.ReceivedCalls());
    }

    [Fact]
    public async Task CreateTaskItem_WithString_ExpectSuccessAsync()
    {
        //Arrange
        Setup(taskItemTitle: "Create Task Item Test");
        await _sut.CreateTaskItemAsync(CreateTaskItemRequest);

        //Act
        var taskItems = await _sut.GetTaskItemsAsync();

        //Assert
        Assert.Contains(taskItems, taskItem => taskItem.Title == CreateTaskItemRequest.TaskItemTitle);
        Assert.Equal(2,_taskItemRepository.ReceivedCalls().Count());
    }

    protected override void Setup(string taskItemTitle)
    {
        CreateTaskItemRequest = new CreateTaskItemRequest
        {
            TaskItemTitle = taskItemTitle
        };

        _sut.GetTaskItemsAsync().Returns([new TaskItem { Title = taskItemTitle }]);
    }
}
