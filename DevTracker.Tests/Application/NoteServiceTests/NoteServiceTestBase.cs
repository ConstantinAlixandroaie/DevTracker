using DevTracker.Application.Interfaces;
using DevTracker.Application.Services;
using DevTracker.Data.Repositories.Interfaces;
using NSubstitute;

namespace DevTracker.Tests.Application.NoteServiceTests;

public class NoteServiceTestBase : IDisposable
{
    protected int CallsToNoteRepository;
    protected INoteRepository _noteRepository = Substitute.For<INoteRepository>();
    protected INoteService _sut;

    protected NoteServiceTestBase()
    {
        _sut = Substitute.For<NoteService>(_noteRepository);
    }
    public void Dispose()
    {
    }
}
