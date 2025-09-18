using DevTracker.Application.Interfaces;
using DevTracker.Application.Services;
using DevTracker.Data.Repositories.Interfaces;
using NSubstitute;

namespace DevTracker.Application.Tests.NoteServiceTests;

public class TestBase : IDisposable
{
    protected INoteRepository _noteRepository = Substitute.For<INoteRepository>();
    protected INoteService _sut;
    protected string? NoteContent;
    protected int TaskId;
    protected string? ErrorMessage;

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
        NoteContent = noteContent;
        TaskId = taskId;
        ErrorMessage = errorMessage;
    }
}
