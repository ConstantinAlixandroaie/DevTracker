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
            return Result<Note>.Failure(ErrorType.NotFound, "Task not Found.");
        }

        note.TaskItemId = taskItem.Id;

        try
        {
            await _ctx.Notes.AddAsync(note);
            await _ctx.SaveChangesAsync();
            return Result<Note>.Success(note);
        }
        catch (DbUpdateException ex)
        {
            return Result<Note>.Failure(ErrorType.Unexpected, ex.Message);
        }
    }

    public async Task<Result<Note>> DeleteNoteAsync(long noteId)
    {
        var note = _ctx.Notes.FirstOrDefault(note => note.Id == noteId);

        if (note == null)
        {
            return Result<Note>.Failure(ErrorType.NotFound, "Note not found.");
        }

        try
        {
            _ctx.Notes.Remove(note);
            await _ctx.SaveChangesAsync();
            return Result<Note>.Success(note);
        }
        catch (DbUpdateException ex)
        {
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
            return Result<IEnumerable<Note>>.Failure(ErrorType.NotFound, ex.Message);
        }
    }

    public async Task<Result<Note>> UpdateNoteAsync(long noteId, string content)
    {
        var note = _ctx.Notes.FirstOrDefault(note => note.Id == noteId);
        if (note == null)
        {
            return Result<Note>.Failure(ErrorType.NotFound, "Note not found.");
        }

        if (note.Content == content)
        {
            return Result<Note>.Failure(ErrorType.Validation, "Note content not changed.");
        }

        note.Content = content;
        try
        {
            await _ctx.SaveChangesAsync();
            return Result<Note>.Success(note);
        }
        catch (DbUpdateException ex)
        {
            return Result<Note>.Failure(ErrorType.Unexpected, ex.Message);
        }
    }
}
