using DevTracker.API.Extensions;
using DevTracker.Application.Interfaces;
using DevTracker.Contracts;
using DevTracker.Contracts.Requests.Notes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevTracker.API.Controllers;

/// <summary>
/// Provides endpoints for Note operations.
/// </summary>
[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class NoteController : ControllerBase
{
    private readonly INoteService _noteService;
    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }

    /// <summary>
    /// Retrieves all notes of a specified task.
    /// </summary>
    /// <param name="taskId">
    /// The task item identifier
    /// </param>
    /// <returns> A response containing a collection of notes for a specific task.
    /// </returns>
    [HttpGet]
    [Route("getNotes")]
    public async Task<IActionResult> GetNotes([FromQuery] long taskId)
    {
        var response = await _noteService.GetNotesAsync(taskId);
        if (response.Result != Result.Success)
        {
            return NotFound(response.ErrorMessage);
        }

        return Ok(response.Notes);
    }

    /// <summary>
    /// Adds a note to a specified task item.
    /// </summary>
    /// <param name="request">A request object containing the details for adding
    ///the note like task identifier and note content.</param>
    /// <returns>An IAction result that contains the succes or failure of the operation.
    /// </returns>
    [HttpPost]
    [Route("addNote")]
    public async Task<IActionResult> AddNoteAsync([FromBody] AddNoteRequest request)
    {
        var userId = User.GetUserId();
        if (userId is null)
        {
            return BadRequest();
        }

        request.UserId = (long)userId;

        var response = await _noteService.AddNoteAsync(request);

        if (response.Result != Result.Success)
        {
            return BadRequest(response.ErrorMessage);
        }

        return Ok(response);
    }

    /// <summary>
    /// Updates a note.
    /// </summary>
    /// <param name="request">A request object containing note identifier and content.
    /// </param>
    /// <returns>An IAction result containing the details of the updated note.
    /// </returns>
    [HttpPut]
    [Route("updateNote")]
    public async Task<IActionResult> UpdateNote([FromBody] UpdateNoteRequest request)
    {
        var userId = User.GetUserId();
        if (userId is null)
        {
            return BadRequest();
        }

        request.UserId = (long)userId;

        var response = await _noteService.UpdateNoteAsync(request);

        if (response.Result != Result.Success)
        {
            return BadRequest(response.ErrorMessage);
        }

        return Ok(response);
    }

    /// <summary>
    /// Deletes a note.
    /// </summary>
    /// <param name="noteId">Indentifier of the note to be deleted.
    /// </param>
    /// <returns>An IAction result containing the details of the deleted note.
    /// </returns>
    [HttpDelete]
    [Route("deleteNote")]
    public async Task<IActionResult> DeleteNote([FromQuery] long noteId)
    {
        var response = await _noteService.DeleteNoteAsync(noteId);

        if (response.Result != Result.Success)
        {
            return BadRequest(response.ErrorMessage);
        }

        return Ok(response);
    }
}
