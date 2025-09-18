using DevTracker.Contracts;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.TaskItemServiceTests;

public class DeleteTaskItemTests : TestBase
{
    [Fact]
    public async Task DeleteTaskItem_RepoReturnsFailure_ExpectFailure()
    {
        //Arrange
        var repoResult = Result<TaskItem>.Failure(ErrorType.Unexpected, ErrorMessage!);
        _taskItemRepository.DeleteTaskItemAsync(TaskId)
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.DeleteTaskItemAsync(TaskId);
        //Assert
        Assert.Equal(ErrorMessage, response.ErrorMessage);
        Assert.Equal(Result.Failure, response.Result);
    }

    [Fact]
    public async Task DeleteTaskItem_RepoReturnsSuccess_ExpectSuccess()
    {
        //Arrange
        var repoResult = Result<TaskItem>.Success(new());
        _taskItemRepository.DeleteTaskItemAsync(TaskId)
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.DeleteTaskItemAsync(TaskId);

        //Assert
        Assert.Null(response.ErrorMessage);
        Assert.Equal(Result.Success, response.Result);
    }

}
