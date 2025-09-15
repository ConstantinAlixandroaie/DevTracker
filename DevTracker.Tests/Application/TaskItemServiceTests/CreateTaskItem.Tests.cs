using DevTracker.Contracts.DTOs;
using NSubstitute;

namespace DevTracker.Tests.Application.TaskItemServiceTests;

public class CreateTaskItemTests : TaskItemTestsBase
{
    [Fact]
    public async Task CreateTaskItem_WithString_ExpectSuccessAsync()
    {
        //Arrange
        Setup(taskItemTitle: "Create Task Item Test");
        CallsToItaskItemRepository = 1;
        //Act
        await _sut.CreateTaskItemAsync(CreateTaskItemRequest);

        //Assert
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
