using DevTracker.Contracts;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.TagServiceTests;

public class DeleteTagTests : TestBase
{
    [Fact]
    public async Task DeleteTag_RepoReturnsFailure_ExpectFailure()
    {
        //Arrange
        const string errorMessage = "Create Failed";
        var repoResult = Result<Tag>.Failure(ErrorType.Conflict, errorMessage);
        _tagRepo.DeleteTagAsync(Arg.Any<long>())
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.DeleteTagAsync(1);

        //Assert
        Assert.Equal(errorMessage, response.ErrorMessage);
        Assert.Equal(Result.Failure, response.Result);
    }
    [Fact]
    public async Task DeleteTag_RepoReturnsSuccess_ExpectSuccess()
    {
        //Arrange
        var repoResult = Result<Tag>.Success(new Tag());
        _tagRepo.DeleteTagAsync(Arg.Any<long>())
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.DeleteTagAsync(1);

        //Assert
        Assert.Null(response.ErrorMessage);
        Assert.Equal(Result.Success, response.Result);
    }
}
