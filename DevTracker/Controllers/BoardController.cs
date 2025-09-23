using DevTracker.API.Extensions;
using DevTracker.Application.Interfaces;
using DevTracker.Contracts;
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
    /// Gets the specified board.
    /// </summary>
    /// <param name="id"> The board Identifier</param>
    /// <returns>A response containing the board details</returns>

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetBoardByIdAsync(string id)
    {
        var response = await _boardService.GetBoardAsync(id);
        if (response.Result == Result.Failure)
        {
            return NotFound();
        }

        return Ok(response);
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
            if (response.Result == Result.Conflict)
            {
                return Conflict();
            }

            return Ok(response);
        }

        return BadRequest();
    }
    /// <summary>
    /// Deletes the specified board.
    /// </summary>
    /// <param name="boardId">The board identifier</param>
    /// <returns>A response containign the success or failure of the request.
    /// </returns>
    [HttpDelete]
    [Route("DeleteBoard")]
    public async Task<IActionResult> DeleteBoardAsync([FromQuery] long boardId)
    {
        var response = await _boardService.DeleteBoardAsync(boardId);
        if (response.Result == Result.Conflict)
        {
            return Conflict();
        }

        return Ok(response);
    }
}
