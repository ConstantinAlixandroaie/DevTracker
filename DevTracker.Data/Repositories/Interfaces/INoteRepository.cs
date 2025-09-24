using DevTracker.Core;
using DevTracker.Data.Models;

namespace DevTracker.Data.Repositories.Interfaces;

public interface INoteRepository
{
    Task<Result<Note>> AddNoteAsync(long userId, long taskItemId, string noteContent);
    Task<Result<IEnumerable<Note>>> GetNotesAsync(long taskId);
    Task<Result<Note>> UpdateNoteAsync(long noteId, string content, long UserId);
    Task<Result<Note>> DeleteNoteAsync(long noteId);
}
