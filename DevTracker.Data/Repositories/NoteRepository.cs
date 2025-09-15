using DevTracker.Data.Models;
using DevTracker.Data.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace DevTracker.Data.Repositories;

internal class NoteRepository : BaseRepository, INoteRepository
{
    public NoteRepository(DevTrackerContext ctx, ILogger<BaseRepository> logger) : base(ctx, logger)
    {
    }

    public Task AddNoteAsync(Note note, long taskId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteNoteAsync(long noteId)
    {
        throw new NotImplementedException();
    }

    public Task GetNotesAsync(long taskId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateNoteAsync(long noteId, string content)
    {
        throw new NotImplementedException();
    }
}
