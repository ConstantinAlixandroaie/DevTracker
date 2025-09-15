using DevTracker.Data.Models;

namespace DevTracker.Data.Repositories.Interfaces;

public interface INoteRepository
{
    Task AddNoteAsync(Note note, long taskId);
    Task GetNotesAsync(long taskId);
    Task UpdateNoteAsync(long noteId, string content);
    Task DeleteNoteAsync(long noteId);
}
