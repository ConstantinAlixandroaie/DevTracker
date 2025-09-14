namespace DevTracker.Application.Interfaces;

public interface INoteService
{
    Task AddNoteAsync(string content);
}
