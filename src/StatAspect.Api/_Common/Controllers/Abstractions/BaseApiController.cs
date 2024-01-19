using StatAspect.Api._Common.Extensions;
using StatAspect.Api._Common.Helpers;
using StatAspect.Application._Common.Pipelines.Responses;
using StatAspect.Domain._Common.ValueObjects.Abstractions;
using StatAspect.SharedKernel.Linq.Extensions;
using StatAspect.SharedKernel.OneOf.Extensions;
using StatAspect.SharedKernel.OneOf.Results;
using StatAspect.SharedKernel.OneOf.Results.TargetProperties.Abstractions;

namespace StatAspect.Api._Common.Controllers.Abstractions;

/// <summary>
/// Represents an abstract base controller.
/// </summary>
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public abstract class BaseApiController : ControllerBase
{
    /// <summary>
    /// Creates an <see cref="ObjectResult"/> with conflict details and produces a <see cref="StatusCodes.Status409Conflict"/> response.
    /// </summary>
    protected ObjectResult Conflict<TProp>(AlreadyExists<TProp> result)
        where TProp : struct, IResultTargetPropertyName
    {
        return Problem(
            detail: $"An entry with the specified {result.GetTargetPropertyDisplayName()} already exists.",
            statusCode: StatusCodes.Status409Conflict);
    }

    /// <summary>
    /// Creates a <see cref="CreatedResult"/> that provides a URL to the created entity and produces a <see cref="StatusCodes.Status201Created"/> response.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    protected CreatedResult Created<TController>(ValueIdentity createdId)
        where TController : BaseApiController
    {
        ArgumentNullException.ThrowIfNull(createdId);

        return Created($"{ControllerHelper.GetRouteTemplate<TController>()}/{createdId}", value: null);
    }

    /// <summary>
    /// Extracts the result from the specified pipeline response and creates a corresponding <see cref="IActionResult"/> response.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    protected IActionResult Extract<TResult>(PipelineResponse<TResult> response, Func<TResult, IActionResult> processResult)
    {
        ArgumentNullException.ThrowIfNull(response);
        ArgumentNullException.ThrowIfNull(processResult);

        return response.ValidationFailures.None()
            ? processResult(response.Result!)
            : ValidationProblem(response.ValidationFailures.ToModelStateDictionary());
    }
}