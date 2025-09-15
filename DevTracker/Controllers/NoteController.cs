using Microsoft.AspNetCore.Mvc;

namespace DevTracker.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class NoteController : ControllerBase
{
    [HttpGet]
    [Route("getNotes")]
    public async Task<IActionResult> GetNotes([FromBody] long taskId)
    {
        return Ok("Notes Retrieved Successfully!");
    }

    [HttpPost]
    [Route("addNote")]
    public async Task<IActionResult> AddNote([FromBody] string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            return BadRequest("Note content cannot be empty.");
        }
        return Ok("Note Added Successfully!");
    }

    [HttpPut]
    [Route("updateNote")]
    public async Task<IActionResult> UpdateNote([FromBody] long noteId, string content)
    {
        if (noteId <= 0)
        {
            return BadRequest("Invalid note ID.");
        }
        if (string.IsNullOrWhiteSpace(content))
        {
            return BadRequest("Note content cannot be empty.");
        }
        return Ok("Note Updated Successfully!");
    }

    [HttpDelete]
    [Route("deleteNote")]
    public async Task<IActionResult> DeleteNote([FromQuery] long noteId)
    {
        if (noteId <= 0)
        {
            return BadRequest("Invalid Note Id");
        }

        return Ok("Note Deleted");
    }
}
