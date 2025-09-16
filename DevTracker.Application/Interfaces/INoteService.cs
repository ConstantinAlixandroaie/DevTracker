using DevTracker.Contracts.Responses.Notes;

namespace DevTracker.Application.Interfaces;

public interface INoteService
{
    Task<AddNoteReponse> AddNoteAsync(string content, long taskId);
    Task<GetNoteResponse> GetNotesAsync(long taskId);
    Task<UpdateNoteReponse> UpdateNoteAsync(long noteId, string content);
    Task<DeleteNoteResponse> DeleteNoteAsync(long noteId);
}
