using DevTracker.Contracts;
using DevTracker.Contracts.Requests.Tags;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.TagServiceTests;

public class UpdateTagTests : TestBase
{
    [Fact]
    public async Task UpdateTag_RepoReturnsFailure_ExpectFailure()
    {
        //Arrange
        const string errorMessage = "Update Failed";
        var repoResult = Result<Tag>.Failure(ErrorType.Conflict, errorMessage);
        _tagRepo.UpdateTagAsync(Arg.Any<long>(), Arg.Any<string>(), Arg.Any<string>())
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.UpdateTagAsync(new UpdateTagRequest { TagId = 1, Name = "name", Colour = "colour" });

        //Assert
        Assert.Equal(errorMessage, response.ErrorMessage);
        Assert.Equal(Result.Failure, response.Result);
    }
    [Fact]
    public async Task UpdateTag_RepoReturnsSuccess_ExpectSuccess()
    {
        //Arrange
        var repoResult = Result<Tag>.Success(new Tag());
        _tagRepo.UpdateTagAsync(Arg.Any<long>(), Arg.Any<string>(), Arg.Any<string>())
             .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.UpdateTagAsync(new UpdateTagRequest { TagId = 1, Name = "name", Colour = "colour" });

        //Assert
        Assert.Null(response.ErrorMessage);
        Assert.Equal(Result.Success, response.Result);
    }
}
