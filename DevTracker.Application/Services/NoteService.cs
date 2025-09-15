using DevTracker.Application.Interfaces;

namespace DevTracker.Application.Services;

public class NoteService : INoteService
{
    public Task AddNoteAsync(string content)
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
