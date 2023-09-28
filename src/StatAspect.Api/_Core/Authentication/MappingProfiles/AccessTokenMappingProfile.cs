// ReSharper disable UnusedType.Global

using StatAspect.Api._Core.Authentication.Models.Responses;
using StatAspect.Domain._Core.Authentication.Aggregates;

namespace StatAspect.Api._Core.Authentication.MappingProfiles;

/// <summary>
/// Represents a mapping configuration profile between <see cref="AccessPermission"/> and <see cref="AccessPermissionResponseBody"/>.
/// <remarks>Used only through reflection.</remarks>
/// </summary>
public sealed class AccessPermissionMappingProfile : Profile
{
    public AccessPermissionMappingProfile()
    {
        CreateMap<AccessPermission, AccessPermissionResponseBody>();
    }
}