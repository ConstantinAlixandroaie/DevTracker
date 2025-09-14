using DevTracker.Domain.DTOs;
using DevTracker.Domain.Models;
using NSubstitute;

namespace DevTracker.Tests.Application.TaskItemServiceTests;

public class CreateTaskItemTests : TaskItemTestsBase
{
    private int _callsToItaskItemREpository;

    [Fact]
    public async Task CreateTaskItem_WithEmptyString_ExpectExceptionThrown()
    {
        //Arrange
        Setup(taskItemTitle: "");
        _callsToItaskItemREpository = 0;
        //Act
        await _sut.CreateTaskItemAsync(CreateTaskItemRequest);

        //Assert
        Assert.False(_validator.Validate(CreateTaskItemRequest).IsValid);
        Assert.Equal(_callsToItaskItemREpository, _taskItemRepository.ReceivedCalls().Count());
    }

    [Fact]
    public async Task CreateTaskItem_WithNull_ExpectExceptionThrownAsync()
    {
        //Arrange
        Setup(taskItemTitle: null!);
        _callsToItaskItemREpository = 0;

        //Act
        await _sut.CreateTaskItemAsync(CreateTaskItemRequest);

        //Assert
        Assert.False(_validator.Validate(CreateTaskItemRequest).IsValid);
        Assert.Equal(_callsToItaskItemREpository, _taskItemRepository.ReceivedCalls().Count());
    }

    [Fact]
    public async Task CreateTaskItem_WithString_ExpectSuccessAsync()
    {
        //Arrange
        Setup(taskItemTitle: "Create Task Item Test");
        _callsToItaskItemREpository = 1;
        //Act
        await _sut.CreateTaskItemAsync(CreateTaskItemRequest);

        //Assert
        Assert.True(_validator.Validate(CreateTaskItemRequest).IsValid);
        Assert.Equal(_callsToItaskItemREpository, _taskItemRepository.ReceivedCalls().Count());
    }

    protected override void Setup(string taskItemTitle)
    {
        CreateTaskItemRequest = new CreateTaskItemRequest
        {
            TaskItemTitle = taskItemTitle
        };
    }
}
