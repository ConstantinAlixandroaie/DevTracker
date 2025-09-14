using DevTracker.Domain.DTOs;
using NSubstitute;

namespace DevTracker.Tests.Application.TaskItemServiceTests;

public class CreateTaskItemTests : TaskItemTestsBase
{
    [Fact]
    public async Task CreateTaskItem_WithEmptyString_ExpectExceptionThrown()
    {
        //Arrange
        Setup(taskItemTitle: "");
        CallsToItaskItemRepository = 0;

        //Act
        await _sut.CreateTaskItemAsync(CreateTaskItemRequest);

        //Assert
        Assert.False(_createTaskItemRequestValidator.Validate(CreateTaskItemRequest).IsValid);
        Assert.Equal(CallsToItaskItemRepository, _taskItemRepository.ReceivedCalls().Count());
    }

    [Fact]
    public async Task CreateTaskItem_WithNull_ExpectExceptionThrownAsync()
    {
        //Arrange
        Setup(taskItemTitle: null!);
        CallsToItaskItemRepository = 0;

        //Act
        await _sut.CreateTaskItemAsync(CreateTaskItemRequest);

        //Assert
        Assert.False(_createTaskItemRequestValidator.Validate(CreateTaskItemRequest).IsValid);
        Assert.Equal(CallsToItaskItemRepository, _taskItemRepository.ReceivedCalls().Count());
    }

    [Fact]
    public async Task CreateTaskItem_WithString_ExpectSuccessAsync()
    {
        //Arrange
        Setup(taskItemTitle: "Create Task Item Test");
        CallsToItaskItemRepository = 1;
        //Act
        await _sut.CreateTaskItemAsync(CreateTaskItemRequest);

        //Assert
        Assert.True(_createTaskItemRequestValidator.Validate(CreateTaskItemRequest).IsValid);
        Assert.Equal(CallsToItaskItemRepository, _taskItemRepository.ReceivedCalls().Count());
    }

    protected void Setup(string taskItemTitle)
    {
        CreateTaskItemRequest = new CreateTaskItemRequest
        {
            TaskItemTitle = taskItemTitle
        };
    }
}
