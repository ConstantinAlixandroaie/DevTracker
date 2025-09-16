using DevTracker.Application.Interfaces;
using DevTracker.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DevTracker.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class NoteController : ControllerBase
{
    private readonly INoteService _noteService;
    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }

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

    [HttpPost]
    [Route("addNote")]
    public async Task<IActionResult> AddNote([FromBody] string content,  long taskId)
    {
        var response = await _noteService.AddNoteAsync(content, taskId);
        if (response.Result != Result.Success)
        {
            return BadRequest(response.ErrorMessage);
        }

        return Ok(response);
    }

    [HttpPut]
    [Route("updateNote")]
    public async Task<IActionResult> UpdateNote([FromBody] long noteId, string content)
    {

        var response = await _noteService.UpdateNoteAsync(noteId, content);
        if (response.Result != Result.Success)
        {
            return BadRequest(response.ErrorMessage);
        }

        return Ok(response);
    }

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
