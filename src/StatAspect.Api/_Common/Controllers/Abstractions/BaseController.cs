using StatAspect.Api._Common.Helpers;
using StatAspect.Api._Common.Models.Responses;
using StatAspect.Domain._Common.ValueObjects.Abstractions;
using StatAspect.SharedKernel.Results;
using StatAspect.SharedKernel.Results.TargetProperties.Abstractions;

namespace StatAspect.Api._Common.Controllers.Abstractions;

/// <summary>
/// Represents an abstract base controller.
/// </summary>
[ApiController]
public abstract class BaseController : ControllerBase
{
    /// <summary>
    /// Creates a <see cref="ConflictObjectResult"/> with target property info and produces a <see cref="StatusCodes.Status409Conflict"/> response.
    /// </summary>
    protected ConflictObjectResult Conflict<TProp>(AlreadyExists<TProp> result) where TProp : struct, IResultTargetPropertyName
    {
        return Conflict(new InvalidOperationResponseBody($"An entry with the specified '{result.GetType().GetGenericArguments()[0].Name}' already exists."));
    }

    /// <summary>
    /// Creates a <see cref="CreatedResult"/> that provides a URL to the created entity and produces a <see cref="StatusCodes.Status201Created"/> response.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    protected CreatedResult Created<TController>(ValueIdentity createdId) where TController : BaseController
    {
        ArgumentNullException.ThrowIfNull(createdId);

        return Created($"{ControllerHelper.GetRouteTemplate<TController>()}/{createdId}", value: null);
    }
}