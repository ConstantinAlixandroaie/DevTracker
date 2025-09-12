namespace DevTracker.Application.Services
{
    public interface INoteService
    {
        Task<bool> AddNote(string content);
    }
}
