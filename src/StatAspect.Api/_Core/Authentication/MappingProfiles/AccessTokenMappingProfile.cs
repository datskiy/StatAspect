// ReSharper disable UnusedType.Global

using StatAspect.Api._Core.Authentication.Models.Responses;
using StatAspect.Domain._Core.Authentication.Aggregates;

namespace StatAspect.Api._Core.Authentication.MappingProfiles;

/// <summary>
/// Represents a mapping configuration profile between <see cref="AccessPermission"/> and <see cref="AccessPermissionResponseBody"/> objects.
/// <remarks>Reflection only.</remarks>
/// </summary>
public sealed class AccessPermissionMappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of <see cref="AccessPermissionMappingProfile"/>.
    /// <remarks>Reflection only.</remarks>
    /// </summary>
    public AccessPermissionMappingProfile()
    {
        CreateMap<AccessPermission, AccessPermissionResponseBody>();
    }
}