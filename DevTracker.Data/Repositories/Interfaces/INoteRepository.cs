using DevTracker.Core;
using DevTracker.Data.Models;

namespace DevTracker.Data.Repositories.Interfaces;

public interface INoteRepository
{
    Task<Result<Note>> AddNoteAsync(Note note, long taskId);
    Task<Result<IEnumerable<Note>>> GetNotesAsync(long taskId);
    Task<Result<Note>> UpdateNoteAsync(long noteId, string content);
    Task<Result<Note>> DeleteNoteAsync(long noteId);
}
