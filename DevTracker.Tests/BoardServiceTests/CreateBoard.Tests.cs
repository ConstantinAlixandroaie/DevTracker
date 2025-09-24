using DevTracker.Contracts;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.BoardServiceTests;

public class CreateBoardTests : TestBase
{
    [Fact]
    public async Task CreateBoard_RepoReturnsFailure_ExpectFailure()
    {
        //Arrange
        const string errorMessage = "Create Board Failed.";
        var repoResult = Result<Board>.Failure(ErrorType.Conflict, errorMessage);
        _boardRepo.CreateBoardAsync(Arg.Any<string>(), Arg.Any<long>())
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.CreateBoardAsync(CreateBoardRequest);

        //Assert
        Assert.Equal(Result.Conflict, response.Result);
        Assert.Equal(errorMessage, response.ErrorMessage);
    }

    [Fact]
    public async Task CreateBoard_RepoReturnsSucces_ExpectSucces()
    {
        //Arrange
        var repoResult = Result<Board>.Success(new Board());
        _boardRepo.CreateBoardAsync(Arg.Any<string>(), Arg.Any<long>())
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.CreateBoardAsync(CreateBoardRequest);

        //Assert
        Assert.Equal(Result.Success, response.Result);
        Assert.Null(response.ErrorMessage);
    }
}
