using DevTracker.Application.Interfaces;
using NSubstitute;

namespace DevTracker.Tests.Application.NoteServiceTests;

public class NoteServiceTests
{
    public INoteService _noteServiceMock = Substitute.For<INoteService>();

    [Fact]
    public async Task AddNote_WithEmptyStringContent_ExpectFailure()
    {
        //Arrange
        var noteContent = string.Empty;
        //Act

        //Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _noteServiceMock.AddNoteAsync(noteContent));
    }

    [Fact]
    public async Task AddNote_WithNullContent_ExpectFailure()
    {
        //Arrange
        string? noteContent = null;

        //Act
        var response = await _noteServiceMock.AddNoteAsync(noteContent);

        //Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _noteServiceMock.AddNoteAsync(noteContent));
    }

    [Fact]
    public async Task AddNote_WithContent_ExpectSuccessAsync()
    {
        //Arrange
        const string noteContent = "Create Initial Note Test";

        //Act
        await _noteServiceMock.AddNoteAsync(noteContent);

        //Assert

    }
}
