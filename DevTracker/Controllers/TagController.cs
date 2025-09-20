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
    [HttpGet]
    public async Task<IActionResult> GetTags()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetTag(long id)
    {
        return Ok();
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateTag()
    {
        return Ok();
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateTag()
    {
        return Ok();
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> DeleteTag(long id)
    {
        return Ok();
    }
}
