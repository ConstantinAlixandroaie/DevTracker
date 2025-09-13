namespace DevTracker.Application.Services;

public interface INoteService
{
    Task<bool> AddNoteAsync(string content);
}
