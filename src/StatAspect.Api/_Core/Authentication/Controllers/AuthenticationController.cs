// ReSharper disable UnusedParameter.Local
// ReSharper disable ConvertClosureToMethodGroup

using StatAspect.Api._Common.Controllers.Abstractions;
using StatAspect.Api._Core.Authentication.Models.Requests;
using StatAspect.Api._Core.Authentication.Models.Responses;
using StatAspect.Application._Core.Authentication.Queries;

namespace StatAspect.Api._Core.Authentication.Controllers;

/// <summary>
/// Represents an authentication controller.
/// </summary>
[Route("authentication")]
public sealed class AuthenticationController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Generates and returns an access token if provided with valid user credentials.
    /// </summary>
    [AllowAnonymous]
    [HttpGet("token")]
    public async Task<IActionResult> GetAccessTokenAsync([FromBody] AccessTokenRequestBody request) // TODO: bf/dos protection
    {
        var query = new GetAccessTokenQuery(request.Username, request.Password);
        var result = await _mediator.Send(query);
        return result.Match<IActionResult>(
            accessToken => Ok(_mapper.Map<AccessTokenResponseBody>(accessToken)),
            accessDenied => Unauthorized());
    }
}