using DevTracker.Contracts;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.NoteServiceTests;

public class UpdateNoteTests : TestBase
{
    [Fact]
    public async Task UpdateNote_RepoReturnsFailure_ExpectFailure()
    {
        //Arrange
        Setup(noteContent: string.Empty, taskId: 1, errorMessage: "Content cannot be empty");

        var repoResult = Result<Note>.Failure(ErrorType.Validation, ErrorMessage!);

        _noteRepository.UpdateNoteAsync(TaskId, NoteContent!)
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.UpdateNoteAsync(TaskId, NoteContent!);

        //Assert
        Assert.Equal(ErrorMessage, response.ErrorMessage);
        Assert.Equal(Result.Failure, response.Result);
        Assert.Null(response.Note);
    }

    [Fact]
    public async Task UpdateNote_RepoReturnsSuccess_ExpectSuccess()
    {
        //Arrange
        Setup(noteContent: "Updated Note Content", taskId: 1);

        var repoResult = Result<Note>.Success(new Note { Content = NoteContent });

        _noteRepository.UpdateNoteAsync(TaskId, NoteContent!)
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.UpdateNoteAsync(TaskId, NoteContent!);

        //Assert
        Assert.Null(response.ErrorMessage);
        Assert.Equal(Result.Success, response.Result);
        Assert.Equal(NoteContent, response.Note.Content);
    }
}
