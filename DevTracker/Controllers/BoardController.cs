using DevTracker.API.Helpers;
using DevTracker.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevTracker.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class BoardController : ControllerBase
{
    private readonly IBoardService _boardService;

    public BoardController(IBoardService boardService)
    {
        _boardService = boardService;
    }

    /// <summary>
    /// Gets the boards associated with the logged in user.
    /// </summary>
    /// <returns> A response containing a collection of boards></returns>
    [HttpGet]
    public async Task<IActionResult> GetBoardsAsync()
    {
        var userId = User.GetUserId();

        if (userId is not null)
        {
            var response = await _boardService.GetBoardsByUserIdAsync((long)userId);
            return Ok(response);
        }

        return BadRequest();
    }
}
