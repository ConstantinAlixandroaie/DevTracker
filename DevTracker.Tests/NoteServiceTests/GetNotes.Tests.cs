using DevTracker.Contracts;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.NoteServiceTests;

public class GetNotes : TestBase
{
    [Fact]
    public async Task GetNotes_RepoReturnsFailure_ExpectFailure()
    {
        //Arrange
        Setup(errorMessage: "Notes not found!");

        var repoResult = Result<IEnumerable<Note>>.Failure(ErrorType.NotFound, ErrorMessage!);
        _noteRepository.GetNotesAsync(TaskId)
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.GetNotesAsync(TaskId);

        //Assert
        Assert.Equal(Result.Failure, response.Result);
        Assert.Equal(ErrorMessage, response.ErrorMessage);
    }

    [Fact]
    public async Task GetNotes_RepoReturnsSuccess_ExpectSuccess()
    {
        //Arrange
        var repoResult = Result<IEnumerable<Note>>.Success([]);
        _noteRepository.GetNotesAsync(TaskId)
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.GetNotesAsync(TaskId);

        //Assert
        Assert.Equal(Result.Success, response.Result);
        Assert.Equal(ErrorMessage, response.ErrorMessage);
    }
}
