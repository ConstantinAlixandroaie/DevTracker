using DevTracker.Contracts;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.TagServiceTests;

public class GetTagTests : TestBase
{
    [Fact]
    public async Task GetTag_RepoReturnsFailure_ExpectFailure()
    {
        //Arrange
        const string errorMessage = "Get Failed";
        var repoResult = Result<Tag>.Failure(ErrorType.Conflict, errorMessage);
        _tagRepo.GetTagAsync(Arg.Any<long>())
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.GetTag(1);

        //Assert
        Assert.Equal(errorMessage, response.ErrorMessage);
        Assert.Equal(Result.NotFound, response.Result);
    }
    [Fact]
    public async Task GetTag_RepoReturnsSuccess_ExpectSuccess()
    {
        ///Arrange
        var repoResult = Result<Tag>.Success(new Tag());
        _tagRepo.GetTagAsync(Arg.Any<long>())
            .Returns(Task.FromResult(repoResult));
        //Act
        var response = await _sut.GetTag(1);

        //Assert
        Assert.Null(response.ErrorMessage);
        Assert.Equal(Result.Success, response.Result);
    }
}
