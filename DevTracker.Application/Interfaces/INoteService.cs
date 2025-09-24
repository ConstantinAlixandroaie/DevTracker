using DevTracker.Contracts.Requests.Notes;
using DevTracker.Contracts.Responses.Notes;

namespace DevTracker.Application.Interfaces;
/// <summary>
/// Provides operations for creating, retrieving, updating and deleting Notes
/// associated with tasks.
/// </summary>
public interface INoteService
{
    /// <summary>
    /// Adds a note to the specified task.
    /// </summary>
    /// <param name="request">A request object containing the not details like <see cref="AddNoteRequest"/></param>
    /// <returns>A response object containing the success or failure of the operation <see cref="AddNoteReponse"/></returns>
    Task<AddNoteReponse> AddNoteAsync(AddNoteRequest request);

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
    Task<UpdateNoteReponse> UpdateNoteAsync(UpdateNoteRequest request);

    /// <summary>
    /// Deletes the specified note.
    /// </summary>
    /// <param name="noteId">The identifier of the note to delete.</param>
    /// <returns>A task result contains a <see cref="DeleteNoteResponse"/> 
    /// indicating the result of the deletion.
    /// </returns>
    Task<DeleteNoteResponse> DeleteNoteAsync(long noteId);
}
