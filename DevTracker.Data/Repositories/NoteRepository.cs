using DevTracker.Core;
using DevTracker.Data.Models;
using DevTracker.Data.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace DevTracker.Data.Repositories;

public class NoteRepository : BaseRepository, INoteRepository
{
    public NoteRepository(DevTrackerContext ctx, ILogger<BaseRepository> logger) : base(ctx, logger)
    {
    }

    public Task<Result<Note>> AddNoteAsync(Note note, long taskId)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Note>> DeleteNoteAsync(long noteId)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IEnumerable<Note>>> GetNotesAsync(long taskId)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Note>> UpdateNoteAsync(long noteId, string content)
    {
        throw new NotImplementedException();
    }
}
