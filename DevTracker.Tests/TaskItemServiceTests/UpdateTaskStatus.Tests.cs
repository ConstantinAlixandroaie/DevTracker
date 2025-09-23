using DevTracker.Contracts;
using DevTracker.Core;
using DevTracker.Data.Enums;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.TaskItemServiceTests;

public class UpdateTaskStatusTests : TestBase
{
    [Fact]
    public async Task UpdateTaskStatus_ExpectSuccesAsync()
    {
        //Arrange
        var repoResult = Result<TaskItem>.Success(new TaskItem());
        _taskItemRepository.UpdateTaskItemStatusAsync(Arg.Any<long>(), Arg.Any<Status>())
             .Returns(Task.FromResult(repoResult));
        //Act
        var response = await _sut.UpdateTaskStatusAsync(_updateTaskItemRequest!);

        //Assert
        Assert.Equal(Result.Success, response.Result);
        Assert.Null(response.ErrorMessage);
    }

    [Fact]
    public async Task UpdateTaskStatus_RepoReturnsFailure_ExpectFailureAsync()
    {
        //Arrange
        var repoResult = Result<TaskItem>.Failure(ErrorType.NotFound, ErrorMessage!);
        _taskItemRepository.UpdateTaskItemStatusAsync(Arg.Any<long>(), Arg.Any<Status>())
             .Returns(Task.FromResult(repoResult));
        //Act
        var response = await _sut.UpdateTaskStatusAsync(_updateTaskItemRequest!);

        //Assert
        Assert.Equal(Result.Failure, response.Result);
        Assert.Equal(ErrorMessage, response.ErrorMessage);
    }
}
