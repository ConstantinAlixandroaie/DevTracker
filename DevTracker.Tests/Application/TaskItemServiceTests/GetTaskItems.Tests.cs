using NSubstitute;
using System.Threading.Tasks;

namespace DevTracker.Tests.Application.TaskItemServiceTests;

public class GetTaskItemsTest : TaskItemTestsBase
{
    [Fact]
    public async Task GetTaskItem_CallsItemRepository()
    {
        //Arrange
        CallsToItaskItemRepository = 1;
        //Act
        await _sut.GetTaskItemsAsync();

        //Assert
        Assert.Equal(CallsToItaskItemRepository, _taskItemRepository.ReceivedCalls().Count());
    }
}
