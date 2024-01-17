using StatAspect.Api._Common.Controllers.Abstractions;

namespace StatAspect.Api._Core.Availability.Controllers;

/// <summary>
/// Represents a ping controller.
/// </summary>
[Route("ping")]
[ApiExplorerSettings(GroupName = "API Availability")]
public sealed class PingController : BaseApiController
{
    /// <summary>
    /// Pings the API to check it availability.
    /// </summary>
    /// <response code="200">The API is available.</response>
    [HttpGet]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public IActionResult Ping()
    {
        return Ok("Pong");
    }
}