using StatAspect.Api._Core.Authentication.Models.Responses;
using StatAspect.Domain._Core.Authentication.Aggregates;

namespace StatAspect.Api._Core.Authentication.Mappers;

/// <summary>
/// Provides a set of mapping methods for <see cref="AccessPermission"/> objects.
/// </summary>
[Mapper]
public static partial class AccessPermissionMapper
{
    /// <summary>
    /// Maps the source <see cref="AccessPermission"/> object to the destination <see cref="AccessPermissionResponseBody"/> object.
    /// </summary>
    /// <remarks>Source generated implementation.</remarks>
    /// <exception cref="NullReferenceException"/>>
    public static partial AccessPermissionResponseBody MapToResponseBody(this AccessPermission accessPermission);
}