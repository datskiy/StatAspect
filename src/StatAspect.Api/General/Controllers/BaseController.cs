using StatAspect.Api.General.Helpers;
using StatAspect.Api.General.Models.Response;
using StatAspect.Domain.General.ValueObjects.Abstractions.Identifiers;
using StatAspect.SharedKernel.Results;
using StatAspect.SharedKernel.Results.Properties.Abstractions;

namespace StatAspect.Api.General.Controllers;

/// <summary>
/// Represents a base API controller.
/// </summary>
[ApiController]
public abstract class BaseController : ControllerBase
{
    /// <summary>
    /// Creates a <see cref="ConflictObjectResult"/> with already existing property info and produces a <see cref="StatusCodes.Status409Conflict"/> response.
    /// </summary>
    protected ConflictObjectResult Conflict<T>(AlreadyExists<T> result) where T : struct, IResultPropertyName
    {
        return Conflict(new InvalidOperationResponse
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