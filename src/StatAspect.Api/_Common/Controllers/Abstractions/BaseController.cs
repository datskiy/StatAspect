using StatAspect.Api._Common.Helpers;
using StatAspect.Api._Common.Models.Responses;
using StatAspect.Domain._Common.ValueObjects.Abstractions.Identifiers;
using StatAspect.SharedKernel.Results;
using StatAspect.SharedKernel.Results.TargetProperties.Abstractions;

namespace StatAspect.Api._Common.Controllers.Abstractions;

/// <summary>
/// Represents a base API controller.
/// </summary>
[ApiController]
public abstract class BaseController : ControllerBase
{
    /// <summary>
    /// Creates a <see cref="ConflictObjectResult"/> with already existing property info and produces a <see cref="StatusCodes.Status409Conflict"/> response.
    /// </summary>
    protected ConflictObjectResult Conflict<T>(AlreadyExists<T> result) where T : struct, IResultTargetPropertyName
    {
        return Conflict(new InvalidOperationResponseBody
        {
            Error = $"The entity with specified '{result.GetType().GetGenericArguments()[0].Name}' already exists"
        });
    }

    /// <summary>
    /// Creates a <see cref="CreatedResult"/> that provides a link to the created entity and produces a <see cref="StatusCodes.Status201Created"/> response.
    /// </summary>
    protected CreatedResult Created<T>(ObjectId createdId) where T : BaseController
    {
        return Created($"{ControllerHelper.GetRouteTemplate<T>()}/{createdId}", value: null);
    }
}