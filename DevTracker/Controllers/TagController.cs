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
        //create tag with name and colour
        //validate colour to be hex code
        return Ok();
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateTag()
    {
        //Update tag with name and/or colour
        //validate colour to be hex code
        return Ok();
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> DeleteTag(long id)
    {
        return Ok();
    }
}
