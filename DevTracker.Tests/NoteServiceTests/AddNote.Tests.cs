using DevTracker.Contracts;
using DevTracker.Contracts.Requests.Notes;
using DevTracker.Core;
using DevTracker.Data.Models;
using NSubstitute;

namespace DevTracker.Application.Tests.NoteServiceTests;

public class AddNoteTests : TestBase
{

    [Fact]
    public async Task AddNote_WithEmptyStringContent_ExpectFailure()
    {
        //Arrange
        const string errorMessage = "Content cannot be empty";

        Setup(errorMessage: errorMessage);

        var repoResult = Result<Note>.Failure(ErrorType.Validation, ErrorMessage!);

        _noteRepository.AddNoteAsync(Arg.Any<Note>())
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.AddNoteAsync(AddRequest!);

        //Assert
        Assert.Equal(ErrorMessage, response.ErrorMessage);
        Assert.Equal(Result.Failure, response.Result);
    }

    [Fact]
    public async Task AddNote_WithNullContent_ExpectFailure()
    {
        //Arrange
        const string? noteContent = "";
        const string errorMessage = "Content cannot be empty";
        Setup(noteContent: noteContent, errorMessage: errorMessage);

        var repoResult = Result<Note>.Failure(ErrorType.Validation, ErrorMessage!);

        _noteRepository.AddNoteAsync(Arg.Any<Note>())
            .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.AddNoteAsync(AddRequest!);

        //Assert
        Assert.Equal(ErrorMessage, response.ErrorMessage);
        Assert.Equal(Result.Failure, response.Result);
    }

    [Fact]
    public async Task AddNote_WithContent_ExpectSuccessAsync()
    {
        //Arrange
        const string noteContent = "Create Initial Note Test";
        Setup(noteContent: noteContent);
        var repoResult = Result<Note>.Success(new Note());

        _noteRepository.AddNoteAsync(Arg.Any<Note>())
          .Returns(Task.FromResult(repoResult));

        //Act
        var response = await _sut.AddNoteAsync(AddRequest!);

        //Assert
        Assert.Null(response.ErrorMessage);
        Assert.Equal(Result.Success, response.Result);
    }
}
