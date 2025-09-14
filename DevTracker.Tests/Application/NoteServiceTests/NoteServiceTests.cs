using DevTracker.Application.Services;
using NSubstitute;

namespace DevTracker.Tests.Application.NoteServiceTests;

public class NoteServiceTests
{
    public INoteService _noteServiceMock = Substitute.For<INoteService>();

    [Fact]
    public async Task CreateNote_WithEmptyStringContent_ExpectArgumentNullException()
    {
        //Arrange
        var noteContent = string.Empty;
        //Act

        //Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _noteServiceMock.AddNoteAsync(noteContent));
    }

    [Fact]
    public async Task CreateNote_WithNullContent_ExpectArgumentNullExceptionAsync()
    {
        //Arrange

        //Act

        //Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _noteServiceMock.AddNoteAsync(null!));
    }

    [Fact]
    public async Task CreateNote_WithContent_ExpectSuccessAsync()
    {
        //Arrange
        const string noteContent = "Create Initial Note Test";

        //Act
        var result = await _noteServiceMock.AddNoteAsync(noteContent);

        //Assert
        Assert.True(result);
    }
}
