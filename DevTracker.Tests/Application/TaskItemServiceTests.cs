using DevTracker.Application.Services;
using NSubstitute;

namespace DevTracker.Tests.Application
{
    public class TaskItemServiceTests
    {
        public ITaskItemService _taskItemServiceMock = Substitute.For<ITaskItemService>();

        [Fact]
        public async Task CreateTaskItem_WithEmptyString_ExpectExceptionThrown()
        {
            //Arrange
            const string taskItemTitle = "";
            //Act
            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _taskItemServiceMock.CreateTaskItem(taskItemTitle));
        }

        [Fact]
        public async Task CreateTaskItem_WithNull_ExpectExceptionThrownAsync()
        {
            //Arrange
            const string taskItemTitle = "";
            //Act
            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _taskItemServiceMock.CreateTaskItem(taskItemTitle));
        }

        [Fact]
        public async Task CreateTaskItem_WithString_ExpectSuccessAsync()
        {
            //Arrange
            const string taskItemTitle = "Create TaskItem Title";
            //Act
            var result = await _taskItemServiceMock.CreateTaskItem(taskItemTitle);
            //Assert
            Assert.True(result);
        }
    }
}
