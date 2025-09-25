using DevTracker.Contracts;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.BoardServiceTests;

public class UpdateBoardTests : TestBase
{
    [Fact]
    public async Task UpdateBoard_RepoReturnsFailure_ExpectFailure()
    {
        //Arrange
        const string errorMessage = "Create Board Failed.";
        var repoResult = Result<Board>.Failure(ErrorType.Conflict, errorMessage);
        _boardRepo.UpdateBoardAsync(Arg.Any<long>(), Arg.Any<string>())
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.UpdateBoardAsync(UpdateBoardRequest);

        //Assert
        Assert.Equal(Result.Conflict, response.Result);
        Assert.Equal(errorMessage, response.ErrorMessage);
    }

    [Fact]
    public async Task UpdateBoard_RepoReturnsSucces_ExpectSucces()
    {
        //Arrange
        var repoResult = Result<Board>.Success(new Board());
        _boardRepo.UpdateBoardAsync(Arg.Any<long>(), Arg.Any<string>())
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.UpdateBoardAsync(UpdateBoardRequest);

        //Assert
        Assert.Equal(Result.Success, response.Result);
        Assert.Null(response.ErrorMessage);
    }
}
