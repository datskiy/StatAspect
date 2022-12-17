using StatAspect.Api.General.Models.Response;
using StatAspect.SharedKernel.Results;
using StatAspect.SharedKernel.Results.Properties.Abstractions;

namespace StatAspect.Api.General.Controllers;

/// <summary>
/// Represents a ping controller for checking API availability.
/// </summary>
[ApiController]
public class BaseController : ControllerBase
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
}