using DevTracker.Contracts;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.TagServiceTests;

public class GetTagsTests : TestBase
{
    [Fact]
    public async Task GetTags_RepoReturnsFailure_ExpectFailure()
    {
        //Arrange
        const string errorMessage = "Get Failed";
        var repoResult = Result<IEnumerable<Tag>>.Failure(ErrorType.Conflict, errorMessage);
        _tagRepo.GetTagsAsync()
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.GetTagsAsync();

        //Assert
        Assert.Equal(errorMessage, response.ErrorMessage);
        Assert.Equal(Result.NotFound, response.Result);
    }
    [Fact]
    public async Task GetTags_RepoReturnsSuccess_ExpectSuccess()
    {
        ///Arrange
        var repoResult = Result<IEnumerable<Tag>>.Success([]);
        _tagRepo.GetTagsAsync()
            .Returns(Task.FromResult(repoResult));
        //Act
        var response = await _sut.GetTagsAsync();

        //Assert
        Assert.Null(response.ErrorMessage);
        Assert.Equal(Result.Success, response.Result);
    }
}
