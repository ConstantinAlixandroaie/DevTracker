using DevTracker.Contracts;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.TaskItemServiceTests;

public class CreateTaskItemTests : TestBase
{
    [Fact]
    public async Task CreateTaskItem_RepoReturnsSuccess_ExpectSuccessAsync()
    {
        //Arrange
        var repoResult = Result<TaskItem>.Success(new TaskItem());
        _taskItemRepository.CreateTaskItemAsync(Arg.Any<string>())
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.CreateTaskItemAsync(CreateTaskItemRequest!);

        //Assert
        Assert.Equal(Result.Success, response.Result);
        Assert.Null(response.ErrorMessage);
    }

    [Fact]
    public async Task CreateTaskItem_RepoReturnsFailure_ExpectFailAsync()
    {
        //Arrange
        var repoResult = Result<TaskItem>.Failure(ErrorType.Validation, ErrorMessage!);
        _taskItemRepository.CreateTaskItemAsync(Arg.Any<string>())
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.CreateTaskItemAsync(CreateTaskItemRequest!);

        //Assert
        Assert.Equal(Result.Failure, response.Result);
        Assert.Equal(ErrorMessage, response.ErrorMessage);
    }
}
