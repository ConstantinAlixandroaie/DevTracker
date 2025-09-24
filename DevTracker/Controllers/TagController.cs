using DevTracker.API.Extensions;
using DevTracker.Application.Interfaces;
using DevTracker.Contracts;
using DevTracker.Contracts.Requests.Tags;
using DevTracker.Core;
using DevTracker.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevTracker.API.Controllers;

/// <summary>
/// Provides endpoints for Tag operations.
/// </summary>
[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class TagController : ControllerBase
{
    private readonly ITagService _tagService;
    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }
    [HttpGet]
    public async Task<IActionResult> GetTagsAsync()
    {
        var response = await _tagService.GetTagsAsync();
        if (response.Result != Result.Success)
        {
            return NotFound(response.ErrorMessage);
        }

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetTagAsync(long id)
    {
        var response = await _tagService.GetTagAsync(id);
        if (response.Result != Result.Success)
        {
            return NotFound(response.ErrorMessage);
        }

        return Ok(response);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateTagAsync([FromBody] CreateTagRequest request)
    {
        var userId = User.GetUserId();
        if (userId is null)
        {
            return BadRequest();
        }

        request.UserId = (long)userId;

        var response = await _tagService.CreateTagAsync(request);
        if (response.Result != Result.Success)
        {
            return Conflict(response.ErrorMessage);
        }

        return Ok(response);
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateTagAsync([FromBody] UpdateTagRequest request)
    {
        var response = await _tagService.UpdateTagAsync(request);
        if (response.Result != Result.Success)
        {
            return BadRequest(response.ErrorMessage);
        }
        return Ok(response);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> DeleteTagAsync(long id)
    {
        var response = await _tagService.DeleteTagAsync(id);

        if (response.Result != Result.Success)
        {
            return NotFound(response.ErrorMessage);
        }
        return Ok(response);
    }
}
