using DevTracker.Application.Interfaces;
using DevTracker.Contracts;
using DevTracker.Contracts.Responses.Notes;
using DevTracker.Data.Models;
using DevTracker.Data.Repositories.Interfaces;

namespace DevTracker.Application.Services;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepo;

    public NoteService(INoteRepository noteRepo)
    {
        _noteRepo = noteRepo;
    }

    public async Task<AddNoteReponse> AddNoteAsync(long taskId, string content)
    {
        var note = new Note
        {
            Content = content
        };

        var result = await _noteRepo.AddNoteAsync(note, taskId);

        if (!result.IsSuccess)
        {
            return new AddNoteReponse(Result.Failure, result.Error);
        }

        return new AddNoteReponse(Result.Success);
    }

    public async Task<DeleteNoteResponse> DeleteNoteAsync(long noteId)
    {
        var result = await _noteRepo.DeleteNoteAsync(noteId);
        if (!result.IsSuccess)
        {
            return new DeleteNoteResponse(Result.NotFound, result.Error);
        }

        return new DeleteNoteResponse(Result.Success);
    }

    public async Task<GetNoteResponse> GetNotesAsync(long taskId)
    {
        var result = await _noteRepo.GetNotesAsync(taskId);

        if (!result.IsSuccess)
        {
            return GetNoteResponse.Failure(Result.Failure, result.Error);
        }

        return GetNoteResponse.Success(Result.Success, result.Value);
    }

    public async Task<UpdateNoteReponse> UpdateNoteAsync(long noteId, string content)
    {
        var result = await _noteRepo.UpdateNoteAsync(noteId, content);
        if (!result.IsSuccess)
        {
            return UpdateNoteReponse.Failure(Result.Failure, result.Error);
        }

        return UpdateNoteReponse.Success(Result.Success, result.Value);
    }
}
