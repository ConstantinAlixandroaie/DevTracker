using DevTracker.Contracts;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Tests.Application.NoteServiceTests;

public class NoteServiceTests : NoteServiceTestBase
{

    [Fact]
    public async Task AddNote_WithEmptyStringContent_ExpectFailure()
    {
        //Arrange
        var noteContent = string.Empty;
        const int taskId = 1;
        const string errorMessage = "Content cannot be empty";
        var repoResult = Result<Note>.Failure(ErrorType.Validation, errorMessage);

        _noteRepository.AddNoteAsync(Arg.Any<Note>(), Arg.Any<long>())
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.AddNoteAsync(noteContent, taskId);

        //Assert
        Assert.Equal(errorMessage, response.ErrorMessage);
        Assert.Equal(Result.Failure, response.Result);
    }

    [Fact]
    public async Task AddNote_WithNullContent_ExpectFailure()
    {
        //Arrange
        string? noteContent = null;
        const int taskId = 1;
        const string errorMessage = "Content cannot be empty";
        var repoResult = Result<Note>.Failure(ErrorType.Validation, errorMessage);

        _noteRepository.AddNoteAsync(Arg.Any<Note>(), Arg.Any<long>())
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.AddNoteAsync(noteContent, taskId);

        //Assert
        Assert.Equal(errorMessage, response.ErrorMessage);
        Assert.Equal(Result.Failure, response.Result);
    }

    [Fact]
    public async Task AddNote_WithContent_ExpectSuccessAsync()
    {
        //Arrange
        const string noteContent = "Create Initial Note Test";
        const int taskId = 1;
        var repoResult = Result<Note>.Success(new Note());
        _noteRepository.AddNoteAsync(Arg.Any<Note>(), Arg.Any<long>())
          .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.AddNoteAsync(noteContent, taskId);

        //Assert
        Assert.Null(response.ErrorMessage);
        Assert.Equal(Result.Success, response.Result);
    }
}
