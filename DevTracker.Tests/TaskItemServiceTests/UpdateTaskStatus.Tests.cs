using DevTracker.Contracts;
using DevTracker.Contracts.Requests.TaskItems;
using DevTracker.Core;
using DevTracker.Data.Enums;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.TaskItemServiceTests;

public class UpdateTaskStatusTests : TestBase
{
    protected UpdateTaskItemRequest? _updateTaskItemRequest;

    [Fact]
    public async Task UpdateTaskStatus_ExpectSuccesAsync()
    {
        //Arrange
        CallsToItaskItemRepository = 1;
        Setup(1, Status.InProgress);
        var repoResult = Result<TaskItem>.Success(new TaskItem());
        _taskItemRepository.UpdateTaskItemStatusAsync(_updateTaskItemRequest!.TaskId, _updateTaskItemRequest.Status)
             .Returns(Task.FromResult(repoResult));
        //Act
        var response = await _sut.UpdateTaskStatusAsync(_updateTaskItemRequest!);

        //Assert
        Assert.Equal(Result.Success, response.Result);
        Assert.Null(response.ErrorMessage);
        Assert.Equal(CallsToItaskItemRepository, _taskItemRepository.ReceivedCalls().Count());
    }

    [Fact]
    public async Task UpdateTaskStatus_RepoReturnsFailure_ExpectFailureAsync()
    {
        //Arrange
        CallsToItaskItemRepository = 1;
        Setup(1, Status.ToDo);
        const string errorMessage = "Task item not found.";
        var repoResult = Result<TaskItem>.Failure(ErrorType.NotFound, errorMessage);
        _taskItemRepository.UpdateTaskItemStatusAsync(_updateTaskItemRequest!.TaskId, _updateTaskItemRequest.Status)
             .Returns(Task.FromResult(repoResult));
        //Act
        var response = await _sut.UpdateTaskStatusAsync(_updateTaskItemRequest!);

        //Assert
        Assert.Equal(Result.Failure, response.Result);
        Assert.Equal(errorMessage, response.ErrorMessage);
        Assert.Equal(CallsToItaskItemRepository, _taskItemRepository.ReceivedCalls().Count());
    }

    protected void Setup(long id, Status status)
    {
        _updateTaskItemRequest = new UpdateTaskItemRequest
        {
            TaskId = id,
            Status = status
        };
    }
}
