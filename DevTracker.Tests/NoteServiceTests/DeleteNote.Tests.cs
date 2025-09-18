using DevTracker.Contracts;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.NoteServiceTests;

public class DeleteNoteTests : TestBase
{
    [Fact]
    public async Task DeleteNote_RepoReturnsFailure_ExpectFailure()
    {
        //Arrange
        var repoResult = Result<Note>.Failure(ErrorType.Unexpected, ErrorMessage!);
        _noteRepository.DeleteNoteAsync(TaskId)
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.DeleteNoteAsync(TaskId);
        //Assert
        Assert.Equal(ErrorMessage, response.ErrorMessage);
        Assert.Equal(Result.NotFound, response.Result);
    }

    [Fact]
    public async Task DeleteNote_RepoReturnsSuccess_ExpectSuccess()
    {
        //Arrange
        var repoResult = Result<Note>.Success(new());
        _noteRepository.DeleteNoteAsync(TaskId)
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.DeleteNoteAsync(TaskId);

        //Assert
        Assert.Null(response.ErrorMessage);
        Assert.Equal(Result.Success, response.Result);
    }
}
