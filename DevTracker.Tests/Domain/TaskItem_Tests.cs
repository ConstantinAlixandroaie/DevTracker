using DevTracker.Domain.Models;

namespace DevTracker.Tests.Domain
{
    public class TaskItem_Tests
    {
        [Fact]
        public void CreateTaskItem_WithNoTitle_ExpectArgumentNullException()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new TaskItem(null, new List<string>()));
        }

        [Fact]
        public void CreateTaskItem_WithTitle_ExpectSuccess()
        {
            //Arrange
            const string taskItemTitle = "Create Initial TaskItem Test";

            //Act
            var taskItem = new TaskItem(taskItemTitle);

            //Assert
            Assert.True(taskItem.Title == taskItemTitle);
        }
    }
}