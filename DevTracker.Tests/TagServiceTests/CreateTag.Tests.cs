using DevTracker.Contracts;
using DevTracker.Contracts.Requests.Tags;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.TagServiceTests;

public class CreateTagTests : TestBase
{
    [Fact]
    public async Task CreateTag_RepoReturnsFailure_ExpectFailure()
    {
        //Arrange
        const string errorMessage = "Create Failed";
        var repoResult = Result<Tag>.Failure(ErrorType.Conflict, errorMessage);
        _tagRepo.CreateTagAsync(Arg.Any<string>(), Arg.Any<string>())
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.CreateTagAsync(new CreateTagRequest { Colour = "testColour", Name = "testName" });

        //Assert
        Assert.Equal(errorMessage, response.ErrorMessage);
        Assert.Equal(Result.Conflict, response.Result);
    }
    [Fact]
    public async Task CreateTag_RepoReturnsSuccess_ExpectSuccess()
    {
        //Arrange
        var repoResult = Result<Tag>.Success(new Tag());
        _tagRepo.CreateTagAsync(Arg.Any<string>(), Arg.Any<string>())
            .Returns(Task.FromResult(repoResult));
        //Act
        var response = await _sut.CreateTagAsync(new CreateTagRequest { Colour = "testColour", Name = "testName" });

        //Assert
        Assert.Null(response.ErrorMessage);
        Assert.Equal(Result.Success, response.Result);
    }
}
