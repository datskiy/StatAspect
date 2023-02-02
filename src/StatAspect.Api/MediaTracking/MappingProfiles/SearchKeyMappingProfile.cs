using StatAspect.Api.MediaTracking.Models.Responses;
using StatAspect.Domain.MediaTracking.Aggregates;

namespace StatAspect.Api.MediaTracking.MappingProfiles;

/// <summary>
/// Represents a mapping configuration profile between <see cref="SearchKey"/> and <see cref="SearchKeyResponse"/> objects.
/// <remarks>
/// <list type="bullet">
/// <item>Usable via reflection only.</item>
/// </list>
/// </remarks>
/// </summary>
public sealed class SearchKeyMappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of <see cref="SearchKeyMappingProfile"/>.
    /// <remarks>
    /// <list type="bullet">
    /// <item>Usable via reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    public SearchKeyMappingProfile()
    {
        CreateMap<SearchKey, SearchKeyResponse>()
            .ForMember(dest => dest.Id, exp => exp.MapFrom(src => src.Id));
    }
}