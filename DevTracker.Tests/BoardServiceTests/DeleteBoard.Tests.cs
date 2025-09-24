using DevTracker.Contracts;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.BoardServiceTests;

public class DeleteBoardTests : TestBase
{
    [Fact]
    public async Task DeleteTaskItem_RepoReturnsFailure_ExpectFailure()
    {
        //Arrange
        const string errorMessage = "Delete Failed";
        var repoResult = Result<Board>.Failure(ErrorType.Unexpected, errorMessage);

        _boardRepo.DeleteBoardByIdAsync(Arg.Any<long>())
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.DeleteBoardAsync(1);

        //Assert
        Assert.Equal(errorMessage, response.ErrorMessage);
        Assert.Equal(Result.Conflict, response.Result);
    }

    [Fact]
    public async Task DeleteTaskItem_RepoReturnsSuccess_ExpectSuccess()
    {
        //Arrange
        var repoResult = Result<Board>.Success(new());
        _boardRepo.DeleteBoardByIdAsync(Arg.Any<long>())
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.DeleteBoardAsync(1);

        //Assert
        Assert.Null(response.ErrorMessage);
        Assert.Equal(Result.Success, response.Result);
    }
}
