using DevTracker.Contracts.Responses.Notes;

namespace DevTracker.Application.Interfaces;
/// <summary>
/// Provides operations for creating, retrieving, updating and deleting Notes
/// associated with tasks.
/// </summary>
public interface INoteService
{
    /// <summary>
    /// Adds a new note to the specified task.
    /// </summary>
    /// <param name="taskId">The identifier of the task to which the note will be added</param>
    /// <param name="content">The content of the note</param>
    /// <returns>The task result that contains an <see cref="AddNoteReponse"/> 
    /// with details about the created note
    /// </returns>
    Task<AddNoteReponse> AddNoteAsync(long taskId, string content);

    /// <summary>
    /// Retrieves all notes associated with the specified task.
    /// </summary>
    /// <param name="taskId">The identifier of the task whose notes should be retrieved.</param>
    /// <returns>A task result contains
    /// a <see cref="GetNoteResponse"/> with the collection of notes.
    /// </returns>
    Task<GetNoteResponse> GetNotesAsync(long taskId);

    /// <summary>
    /// Updates the content of an existing note.
    /// </summary>
    /// <param name="noteId">The identifier of the note to update.</param>
    /// <param name="content">The new text content for the note.</param>
    /// <returns>A task result contains an <see cref="UpdateNoteReponse"/>
    /// with the updated note details.
    /// </returns>
    Task<UpdateNoteReponse> UpdateNoteAsync(long noteId, string content);

    /// <summary>
    /// Deletes the specified note.
    /// </summary>
    /// <param name="noteId">The identifier of the note to delete.</param>
    /// <returns>A task result contains a <see cref="DeleteNoteResponse"/> 
    /// indicating the result of the deletion.
    /// </returns>
    Task<DeleteNoteResponse> DeleteNoteAsync(long noteId);
}
