using DevTracker.Contracts;
using DevTracker.Core;
using DevTracker.Data.Enums;
using DevTracker.Data.Models;
using DevTracker.Data.Records;
using NSubstitute;

namespace DevTracker.Application.Tests.TaskItemServiceTests;

public class UpdateTaskStatusTests : TestBase
{
    [Fact]
    public async Task UpdateTaskStatus_ExpectSuccesAsync()
    {
        //Arrange
        var repoResult = Result<TaskItem>.Success(new TaskItem());
        _taskItemRepository.UpdateTaskItemAsync(Arg.Any<UpdateTaskItem>())
             .Returns(Task.FromResult(repoResult));
        //Act
        var response = await _sut.UpdateTaskAsync(_updateTaskItemRequest!);

        //Assert
        Assert.Equal(Result.Success, response.Result);
        Assert.Null(response.ErrorMessage);
    }

    [Fact]
    public async Task UpdateTaskStatus_RepoReturnsFailure_ExpectFailureAsync()
    {
        //Arrange
        var repoResult = Result<TaskItem>.Failure(ErrorType.NotFound, ErrorMessage!);
        _taskItemRepository.UpdateTaskItemAsync(Arg.Any<UpdateTaskItem>())
            .Returns(Task.FromResult(repoResult));
        //Act
        var response = await _sut.UpdateTaskAsync(_updateTaskItemRequest!);

        //Assert
        Assert.Equal(Result.NotFound, response.Result);
        Assert.Equal(ErrorMessage, response.ErrorMessage);
    }
}
