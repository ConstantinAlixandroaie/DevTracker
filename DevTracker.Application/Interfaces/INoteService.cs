using DevTracker.Contracts.Responses.Note;

namespace DevTracker.Application.Interfaces;

public interface INoteService
{
    Task<AddNoteReponse> AddNoteAsync(string content);
    Task<GetNoteResponse> GetNotesAsync(long taskId);
    Task<UpdateNoteReponse> UpdateNoteAsync(long noteId, string content);
    Task<DeleteNoteResponse> DeleteNoteAsync(long noteId);
}
