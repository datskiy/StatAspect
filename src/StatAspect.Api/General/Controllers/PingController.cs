namespace StatAspect.Api.General.Controllers;

/// <summary>
/// Represents a ping controller for checking API availability.
/// </summary>
[ApiController]
[Route("ping")]
public sealed class PingController : ControllerBase
{
    public PingController()
    {
    }

    /// <summary>
    /// Checks the API availability.
    /// </summary>
    [HttpGet]
    public IActionResult Ping()
    {
        return Ok(true);
    }
}