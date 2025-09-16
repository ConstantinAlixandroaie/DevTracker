using DevTracker.Contracts.Responses.Notes;

namespace DevTracker.Application.Interfaces;

public interface INoteService
{
    Task<AddNoteReponse> AddNoteAsync(long taskId, string content);
    Task<GetNoteResponse> GetNotesAsync(long taskId);
    Task<UpdateNoteReponse> UpdateNoteAsync(long noteId, string content);
    Task<DeleteNoteResponse> DeleteNoteAsync(long noteId);
}
