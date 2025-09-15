using DevTracker.Contracts.DTOs;
using DevTracker.Domain.Enums;
using NSubstitute;

namespace DevTracker.Tests.Application.TaskItemServiceTests;

public class UpdateTaskStatusTests : TaskItemTestsBase
{
    protected UpdateTaskItemRequest _updateTaskItemRequest;

    [Fact]
    public void UpdateTaskStatus_ExpectSucces()
    {
        //Arrange
        CallsToItaskItemRepository = 1;
        Setup(1, Status.ToDo);

        //Act
        _sut.UpdateTaskStatusAsync(_updateTaskItemRequest);

        //Assert
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
