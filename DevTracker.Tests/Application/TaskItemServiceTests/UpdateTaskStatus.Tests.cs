using DevTracker.Domain.DTOs;
using DevTracker.Domain.Enums;
using FluentValidation;
using NSubstitute;

namespace DevTracker.Tests.Application.TaskItemServiceTests;

public class UpdateTaskStatusTests : TaskItemTestsBase
{
    protected UpdateTaskItemRequest _updateTaskItemRequest;

    [Fact]
    public void UpdateTaskStatus_WithoutTaskId_ExpectValidationError()
    {
        //Arrange
        CallsToItaskItemRepository = 0;
        Setup(0, Status.ToDo);

        //Act
        _sut.UpdateTaskStatusAsync(_updateTaskItemRequest);

        //Assert
        Assert.False(_updateTaskItemRequestValidator.Validate(_updateTaskItemRequest).IsValid);
        Assert.Equal(CallsToItaskItemRepository, _taskItemRepository.ReceivedCalls().Count());

    }

    [Fact]
    public void UpdateTaskStatus_WithoutStatus_ExpectValidationError()
    {
        //Arrange
        CallsToItaskItemRepository = 0;
        Setup(1, 0);

        //Act
        _sut.UpdateTaskStatusAsync(_updateTaskItemRequest);

        //Assert
        Assert.False(_updateTaskItemRequestValidator.Validate(_updateTaskItemRequest).IsValid);
        Assert.Equal(CallsToItaskItemRepository, _taskItemRepository.ReceivedCalls().Count());

    }
    [Fact]
    public void UpdateTaskStatus_ExpectSucces()
    {
        //Arrange
        CallsToItaskItemRepository = 1;
        Setup(1, Status.ToDo);

        //Act
        _sut.UpdateTaskStatusAsync(_updateTaskItemRequest);

        //Assert
        Assert.True(_updateTaskItemRequestValidator.Validate(_updateTaskItemRequest).IsValid);
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
