namespace DevTracker.Tests.Application.TaskItemServiceTests;

public class CreateTaskItemTests : TaskItemTestsBase
{
    [Fact]
    public async Task CreateTaskItem_WithEmptyString_ExpectExceptionThrown()
    {
        //Arrange
        Setup(taskItemTitle: "");

        //Act

        //Assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () => await _sut.CreateTaskItemAsync(_createTaskItemRequest));
    }

    [Fact]
    public async Task CreateTaskItem_WithNull_ExpectExceptionThrownAsync()
    {
        //Arrange
        Setup(taskItemTitle: null!);

        //Act

        //Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _sut.CreateTaskItemAsync(_createTaskItemRequest));
    }

    [Fact]
    public async Task CreateTaskItem_WithString_ExpectSuccessAsync()
    {
        //Arrange
        Setup(taskItemTitle: "Create Task Item Test");

        await _sut.CreateTaskItemAsync(_createTaskItemRequest);
        //Act
        var taskItems = await _sut.GetTaskItemsAsync();

        //Assert
        Assert.Contains(taskItems, taskItem => taskItem.Title == _createTaskItemRequest.TaskItemTitle);
    }
}
