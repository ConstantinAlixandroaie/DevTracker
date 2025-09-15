namespace DevTracker.Application.Interfaces;

public interface INoteService
{
    Task AddNoteAsync(string content);
    Task GetNotesAsync(long taskId);
    Task UpdateNoteAsync(long noteId, string content);
    Task DeleteNoteAsync(long noteId);
}
