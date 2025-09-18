using DevTracker.Contracts;
using DevTracker.Contracts.Requests;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.TaskItemServiceTests;

public class CreateTaskItemTests : TestBase
{
    [Fact]
    public async Task CreateTaskItem_WithString_ExpectSuccessAsync()
    {
        //Arrange
        const string taskItemTitle = "Valid Task";
        Setup(taskItemTitle: taskItemTitle);
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
        var taskItemTitle = string.Empty;
        const string errorMessage = "Task item title cannot be empty.";
        Setup(taskItemTitle: taskItemTitle, errorMessage: errorMessage);
        var repoResult = Result<TaskItem>.Failure(ErrorType.Validation, errorMessage);
        _taskItemRepository.CreateTaskItemAsync(taskItemTitle)
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.CreateTaskItemAsync(CreateTaskItemRequest!);

        //Assert
        Assert.Equal(CallsToItaskItemRepository, _taskItemRepository.ReceivedCalls().Count());
        Assert.Equal(Result.Failure, response.Result);
        Assert.Equal(ErrorMessage, response.ErrorMessage);
    }
}
