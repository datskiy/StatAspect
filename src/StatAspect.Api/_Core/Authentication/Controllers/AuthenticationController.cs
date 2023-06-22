using StatAspect.Api._Common.Controllers.Abstractions;
using StatAspect.Api._Core.Authentication.Models.Requests;
using StatAspect.Application._Core.Authentication.Queries;

namespace StatAspect.Api._Core.Authentication.Controllers;

/// <summary>
/// Represents an authentication controller.
/// </summary>
[AllowAnonymous]
[Route("authentication")]
public sealed class AuthenticationController : BaseController
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Generates and returns a personal access token, if provided with valid user credentials.
    /// </summary>
    [HttpGet("token")]
    public async Task<IActionResult> GetTokenAsync([FromBody] AccessTokenRequestBody request)
    {
        var query = new GetAccessTokenQuery(request.Username, request.Password);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}