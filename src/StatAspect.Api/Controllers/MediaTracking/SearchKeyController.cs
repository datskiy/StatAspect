using StatAspect.Api.Interaction.Requests.MediaTracking;

namespace StatAspect.Api.Controllers;

/// <summary>
/// XXX
/// </summary>
[Route("mediaTracking/[controller]")]
public sealed class SearchKeyController : BaseController
{
    public SearchKeyController()
    {
    }

    /// <summary>
    /// XXX
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAsync([FromQuery] int id)
    {
        await Task.Delay(0);
        return Ok();
    }

    /// <summary>
    /// XXX
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        await Task.Delay(0);
        return Ok();
    }

    /// <summary>
    /// XXX
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddSearchKeyRequest request)
    {
        await Task.Delay(0);
        return Created("searchKey", null);
    }

    /// <summary>
    /// XXX
    /// </summary>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateSearchKeyRequest request)
    {
        await Task.Delay(0);
        return Ok();
    }

    /// <summary>
    /// XXX
    /// </summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromQuery] int id)
    {
        await Task.Delay(0);
        return NoContent();
    }
}