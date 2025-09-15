using DevTracker.Contracts;
using DevTracker.Contracts.Requests;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Tests.Application.TaskItemServiceTests;

public class CreateTaskItemTests : TaskItemTestsBase
{
    [Fact]
    public async Task CreateTaskItem_WithString_ExpectSuccessAsync()
    {
        //Arrange
        CallsToItaskItemRepository = 1;
        var taskItemTitle = "Valid Task";
        Setup(taskItemTitle);
        var repoResult = Result<TaskItem>.Success(new TaskItem());
        _taskItemRepository.CreateTaskItemAsync(taskItemTitle)
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.CreateTaskItemAsync(CreateTaskItemRequest!);

        //Assert
        Assert.Equal(CallsToItaskItemRepository, _taskItemRepository.ReceivedCalls().Count());
        Assert.Equal(Result.Success, response.Result);
        Assert.Null(response.ErrorMessage);
    }

    [Fact]
    public async Task CreateTaskItem_WithEmptyString_ExpectFailAsync()
    {
        //Arrange
        CallsToItaskItemRepository = 1;
        var taskItemTitle = string.Empty;
        var errorMessage = "Task item title cannot be empty.";
        Setup(taskItemTitle);
        var repoResult = Result<TaskItem>.Failure(errorMessage);
        _taskItemRepository.CreateTaskItemAsync(taskItemTitle)
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.CreateTaskItemAsync(CreateTaskItemRequest!);

        //Assert
        Assert.Equal(CallsToItaskItemRepository, _taskItemRepository.ReceivedCalls().Count());
        Assert.Equal(Result.Failure, response.Result);
        Assert.Equal("Task item title cannot be empty.", response.ErrorMessage);
    }

    protected void Setup(string taskItemTitle)
    {
        CreateTaskItemRequest = new CreateTaskItemRequest
        {
            TaskItemTitle = taskItemTitle
        };
    }
}
