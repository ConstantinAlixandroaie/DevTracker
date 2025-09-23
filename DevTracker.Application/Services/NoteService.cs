using DevTracker.Application.Interfaces;
using DevTracker.Contracts;
using DevTracker.Contracts.Requests.Notes;
using DevTracker.Contracts.Responses.Notes;
using DevTracker.Data.Models;
using DevTracker.Data.Repositories.Interfaces;
using DevTracker.Domain.Notes;

namespace DevTracker.Application.Services;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepo;

    public NoteService(INoteRepository noteRepo)
    {
        _noteRepo = noteRepo;
    }

    /// <inheritdoc />
    public async Task<AddNoteReponse> AddNoteAsync(AddNoteRequest request)
    {
        var note = new Note
        {
            Content = request.Content,
            CreatedById = request.UserId,
            TaskItemId = request.TaskItemId
        };

        var result = await _noteRepo.AddNoteAsync(note);

        if (!result.IsSuccess)
        {
            return new AddNoteReponse(Result.Failure, result.Error);
        }

        return new AddNoteReponse(Result.Success);
    }

    /// <inheritdoc />
    public async Task<DeleteNoteResponse> DeleteNoteAsync(long noteId)
    {
        var result = await _noteRepo.DeleteNoteAsync(noteId);
        if (!result.IsSuccess)
        {
            return new DeleteNoteResponse(Result.NotFound, result.Error);
        }

        return new DeleteNoteResponse(Result.Success);
    }

    /// <inheritdoc />
    public async Task<GetNoteResponse> GetNotesAsync(long taskId)
    {
        var result = await _noteRepo.GetNotesAsync(taskId);

        if (!result.IsSuccess)
        {
            return GetNoteResponse.Failure(Result.Failure, result.Error);
        }

        return GetNoteResponse.Success(Result.Success, result.Value);
    }

    /// <inheritdoc />
    public async Task<UpdateNoteReponse> UpdateNoteAsync(UpdateNoteRequest request)
    {
        var result = await _noteRepo.UpdateNoteAsync(request.NoteId, request.Content, request.UserId);

        if (!result.IsSuccess)
        {
            return UpdateNoteReponse.Failure(Result.Failure, result.Error);
        }

        return UpdateNoteReponse.Success(Result.Success, result.Value);
    }
}
