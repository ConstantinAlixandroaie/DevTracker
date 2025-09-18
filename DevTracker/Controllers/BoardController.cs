using DevTracker.API.Helpers;
using DevTracker.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevTracker.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class BoardController : ControllerBase
{
    private readonly IBoardService _boardService;
    public BoardController(IBoardService boardService)
    {
        _boardService = boardService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBoardsAsync()
    {
        //TODO: IMPLEMENT THIS
        var userId = User.GetUserId();

        if (userId is not null)
        {
            var response = await _boardService.GetBoardsByUserIdAsync((long)userId);
            return Ok(userId);
        }
        return BadRequest();
    }
}
