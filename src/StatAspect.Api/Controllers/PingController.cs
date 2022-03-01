namespace StatAspect.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class PingController : ControllerBase
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