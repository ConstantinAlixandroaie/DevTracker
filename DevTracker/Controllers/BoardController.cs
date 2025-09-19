using DevTracker.API.Helpers;
using DevTracker.Application.Interfaces;
using DevTracker.Contracts.Requests.Boards;
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
    /// <returns> A response containing a collection of boards>
    /// </returns>
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

    /// <summary>
    /// Creates a board.
    /// </summary>
    /// <returns> A response with the success or failure of the request.
    /// </returns>
    [HttpPost]
    [Route("CreateBoard")]
    public async Task<IActionResult> CreateBoardAsync([FromBody] string boardTitle)
    {
        var userId = User.GetUserId();
        if (userId is not null)
        {
            var request = new CreateBoardRequest
            {
                BoardTitle = boardTitle,
                UserId = (long)userId
            };

            var response = await _boardService.CreateBoardAsync(request);

            return Ok(response);
        }

        return BadRequest();
    }

    [HttpDelete]
    [Route("DeleteBoard")]
    public async Task<IActionResult> DeleteBoardAsync([FromQuery] long boardId)
    {
        var response = await _boardService.DeleteBoardAsync(boardId);

        return Ok(response);
    }
}
