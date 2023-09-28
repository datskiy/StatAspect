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
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public AuthenticationController(
        IMapper mapper,
        IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    /// <summary>
    /// Grants and returns an access permission if provided with valid user credentials.
    /// </summary>
    [AllowAnonymous]
    [HttpGet("token")]
    public async Task<IActionResult> GetAccessPermissionAsync([FromBody] AccessPermissionRequestBody request) // TODO: bf/dos protection
    {
        var query = new GetAccessPermissionQuery(request.Username, request.Password);
        var result = await _mediator.Send(query);

        return result.Match<IActionResult>(
            accessPermission => Ok(_mapper.Map<AccessPermissionResponseBody>(accessPermission)),
            accessDenied => Unauthorized());
    }
}