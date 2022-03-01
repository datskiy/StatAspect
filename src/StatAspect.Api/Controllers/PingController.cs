namespace StatAspect.Api.Controllers;

/// <summary>
/// Represents a ping controller for checking an API accessibility.
/// </summary>
[Route("[controller]")]
public sealed class PingController : BaseController
{
    public PingController()
    {
    }

    /// <summary>
    /// Checks the API accessibility.
    /// </summary>
    /// <returns><see cref="IActionResult"/></returns>
    [HttpGet]
    public IActionResult Ping()
    {
        return Ok();
    }
}