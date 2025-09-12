using DevTracker.Domain.Models;

namespace DevTracker.Tests.Domain
{
    public class Note_Tests
    {
        [Fact]
        public void CreateNote_WithEmptyStringContent_ExpectArgumentNullException()
        {
            //Arrange
            var noteContent = string.Empty;
            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new Note(noteContent));
        }

        [Fact]
        public void CreateNote_WithNullContent_ExpectArgumentNullException()
        {
            //Arrange
            
            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new Note(null!));
        }

        [Fact]
        public void CreateNote_WithContent_ExpectSuccess()
        {
            //Arrange
            const string noteContent = "Create Initial Note Test";

            //Act
            var note = new Note(noteContent);

            //Assert
            Assert.True(note.Content == noteContent);
        }
    }
}
