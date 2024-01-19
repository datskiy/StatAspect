// ReSharper disable UnusedParameter.Local

using StatAspect.Api._Common.Controllers.Abstractions;
using StatAspect.Api._Core.Authentication.Mappers;
using StatAspect.Api._Core.Authentication.Models.Requests;
using StatAspect.Api._Core.Authentication.Models.Responses;
using StatAspect.Application._Core.Authentication.Commands;

namespace StatAspect.Api._Core.Authentication.Controllers;

/// <summary>
/// Represents an access permission controller.
/// </summary>
[Route("authentication")]
[ApiExplorerSettings(GroupName = "API Access")]
public sealed class AccessPermissionController : BaseApiController
{
    private readonly IMediator _mediator;

    public AccessPermissionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Issues a temporary access token if provided with valid user credentials.
    /// </summary>
    /// <param name="request">User credentials for which access token is requested.</param>
    /// <response code="200">The temporary access token has been issued.</response>
    /// <response code="400">The request was invalid.</response>
    /// <response code="401">The user credentials were invalid.</response>
    [AllowAnonymous]
    [HttpPost("issue-access-token")]
    [ProducesResponseType(typeof(AccessPermissionResponseBody), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> IssueAsync([FromBody] AccessPermissionRequestBody request) // TODO: bf/dos protection
    {
        var command = new IssueAccessPermissionCommand(request.Username, request.Password);
        var response = await _mediator.Send(command);

        return Extract(response, result => result.Match<IActionResult>(
            issuedAccessPermission => Ok(issuedAccessPermission.MapToResponseBody()),
            accessDenied => Unauthorized()));
    }
}