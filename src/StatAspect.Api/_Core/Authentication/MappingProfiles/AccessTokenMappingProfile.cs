// ReSharper disable UnusedType.Global

using StatAspect.Api._Core.Authentication.Models.Responses;
using StatAspect.Domain._Core.Authentication.Aggregates;

namespace StatAspect.Api._Core.Authentication.MappingProfiles;

/// <summary>
/// Represents a mapping configuration profile between <see cref="AccessToken"/> and <see cref="AccessTokenResponseBody"/> objects.
/// <remarks>
/// <list type="bullet">
/// <item>Reflection only.</item>
/// </list>
/// </remarks>
/// </summary>
public sealed class AccessTokenMappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of <see cref="AccessTokenMappingProfile"/>.
    /// <remarks>
    /// <list type="bullet">
    /// <item>Reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    public AccessTokenMappingProfile()
    {
        CreateMap<AccessToken, AccessTokenResponseBody>();
    }
}