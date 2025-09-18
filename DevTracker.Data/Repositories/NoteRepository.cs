using DevTracker.Core;
using DevTracker.Data.Models;
using DevTracker.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DevTracker.Data.Repositories;

public class NoteRepository : BaseRepository, INoteRepository
{
    public NoteRepository(DevTrackerContext ctx, ILogger<BaseRepository> logger) : base(ctx, logger)
    {
    }

    public async Task<Result<Note>> AddNoteAsync(Note note, long taskId)
    {
        var taskItem = _ctx.TaskItems.AsNoTracking().FirstOrDefault(taskItem => taskItem.Id == taskId);

        if (taskItem == null)
        {
            _logger.LogError("The task does not exist.");
            return Result<Note>.Failure(ErrorType.NotFound, "Task not Found.");
        }

        note.TaskItemId = taskItem.Id;

        try
        {
            await _ctx.Notes.AddAsync(note);
            await _ctx.SaveChangesAsync();
            _logger.LogInformation($"Note with {note.Id} has been added to task item with id {taskItem.Id}!");
            return Result<Note>.Success(note);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
            return Result<Note>.Failure(ErrorType.Unexpected, ex.Message);
        }
    }

    public async Task<Result<Note>> DeleteNoteAsync(long noteId)
    {
        var note = _ctx.Notes.FirstOrDefault(note => note.Id == noteId);

        if (note == null)
        {
            _logger.LogError("The note does not exist.");
            return Result<Note>.Failure(ErrorType.NotFound, "Note not found.");
        }

        try
        {
            _ctx.Notes.Remove(note);
            await _ctx.SaveChangesAsync();
            _logger.LogInformation($"Note with {note.Id} has beed succesfully deleted.");
            return Result<Note>.Success(note);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
            return Result<Note>.Failure(ErrorType.Unexpected, ex.Message);
        }
    }

    public async Task<Result<IEnumerable<Note>>> GetNotesAsync(long taskId)
    {
        try
        {
            var notes = await _ctx.Notes.AsNoTracking().Where(note => note.TaskItemId == taskId).ToListAsync();
            return Result<IEnumerable<Note>>.Success(notes);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
            return Result<IEnumerable<Note>>.Failure(ErrorType.NotFound, ex.Message);
        }
    }

    public async Task<Result<Note>> UpdateNoteAsync(long noteId, string content)
    {
        var note = _ctx.Notes.FirstOrDefault(note => note.Id == noteId);
        if (note == null)
        {
            _logger.LogError("Note not found.");
            return Result<Note>.Failure(ErrorType.NotFound, "Note not found.");
        }

        if (note.Content == content)
        {
            _logger.LogError("Update note did not change note content.");
            return Result<Note>.Failure(ErrorType.Validation, "Note content not changed.");
        }

        note.Content = content;
        try
        {
            await _ctx.SaveChangesAsync();
            _logger.LogInformation($"Note with id {note.Id} succesfully updated.");
            return Result<Note>.Success(note);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
            return Result<Note>.Failure(ErrorType.Unexpected, ex.Message);
        }
    }
}
