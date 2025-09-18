using DevTracker.Contracts;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.TaskItemServiceTests;

public class GetTaskItemsTest : TestBase
{
    [Fact]
    public async Task GetTaskItem_CallsItemRepository()
    {
        //Arrange
        CallsToItaskItemRepository = 1;
        var repoResult = Result<IEnumerable<TaskItem>>.Success(new List<TaskItem>());
        _taskItemRepository.GetTaskItemsAsync()
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.GetTaskItemsAsync();

        //Assert
        Assert.Equal(Result.Success, response.Result);
        Assert.Null(response.ErrorMessage);
        Assert.Equal(CallsToItaskItemRepository, _taskItemRepository.ReceivedCalls().Count());
    }

    [Fact]
    public async Task GetTaskItem_RepositoryReturnsFailure_ExpectFailure()
    {
        //Arrange
        CallsToItaskItemRepository = 1;
        var errorMessage = "Database connection failed.";
        var repoResult = Result<IEnumerable<TaskItem>>.Failure(ErrorType.Unexpected, errorMessage);
        _taskItemRepository.GetTaskItemsAsync()
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.GetTaskItemsAsync();

        //Assert
        Assert.Equal(Result.Failure, response.Result);
        Assert.Equal(errorMessage, response.ErrorMessage);
        Assert.Equal(CallsToItaskItemRepository, _taskItemRepository.ReceivedCalls().Count());
    }
}
