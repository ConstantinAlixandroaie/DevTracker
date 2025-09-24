using DevTracker.Contracts;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.BoardServiceTests;

public class GetBoardTests : TestBase
{
    [Fact]
    public async Task GetBoards_RepoReturnsFailure_ExpectFailure()
    {
        //Arrange
        const string errorMessage = "Get Boards failed.";
        var repoResult = Result<Board>.Failure(ErrorType.Unexpected, errorMessage);
        _boardRepo.GetBoardAsync(Arg.Any<long>())
            .Returns(Task.FromResult(repoResult));
        //Act
        var response = await _sut.GetBoardAsync("1");
        //Assert
        Assert.Equal(Result.NotFound, response.Result);
        Assert.Equal(errorMessage, response.ErrorMessage);
    }

    [Fact]
    public async Task GetBoards_RepoReturnsSuccess_ExpectSuccess()
    {
        //Arrange
        var repoResult = Result<Board>.Success(new Board());
        _boardRepo.GetBoardAsync(Arg.Any<long>())
            .Returns(Task.FromResult(repoResult));
        //Act
        var response = await _sut.GetBoardAsync("1");

        //Assert
        Assert.Equal(Result.Success, response.Result);
        Assert.Null(response.ErrorMessage);
    }
}
