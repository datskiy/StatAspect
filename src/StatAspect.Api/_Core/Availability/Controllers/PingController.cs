using StatAspect.Api._Common.Controllers.Abstractions;

namespace StatAspect.Api._Core.Availability.Controllers;

/// <summary>
/// Represents a ping controller for checking API availability.
/// </summary>
[Route("ping")]
public sealed class PingController : BaseController
{
    /// <summary>
    /// Returns "Pong" if API is available.
    /// </summary>
    [HttpGet]
    public IActionResult Ping()
    {
        return Ok("Pong");
    }
}