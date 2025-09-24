using DevTracker.Application.Interfaces;
using DevTracker.Application.Services;
using DevTracker.Contracts.Requests.Notes;
using DevTracker.Data.Repositories.Interfaces;
using NSubstitute;

namespace DevTracker.Application.Tests.NoteServiceTests;

public class TestBase : IDisposable
{
    protected INoteRepository _noteRepository = Substitute.For<INoteRepository>();
    protected INoteService _sut;
    protected string? NoteContent;
    protected long TaskId;
    protected long UserId;
    protected string? ErrorMessage;
    protected AddNoteRequest? AddRequest;
    protected UpdateNoteRequest? UpdateRequest;

    protected TestBase()
    {
        _sut = Substitute.For<NoteService>(_noteRepository);
        Setup();
    }

    public void Dispose()
    {
    }

    protected void Setup(string? noteContent = null, int taskId = 1, string? errorMessage = null)
    {
        AddRequest = new AddNoteRequest
        {
            Content = noteContent!,
            TaskItemId = taskId,
            UserId = 1,
        };
        UpdateRequest = new UpdateNoteRequest
        {
            Content = noteContent!,
            NoteId = 1,
            UserId = 1
        };

        ErrorMessage = errorMessage;
    }
}
