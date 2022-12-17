using StatAspect.Api.MediaTracking.Models.Responses;
using StatAspect.Domain.MediaTracking.ValueObjects;

namespace StatAspect.Api.MediaTracking.Profilers;

/// <summary>
/// Represents a mapping configuration profile between <see cref="SearchKey"/> and <see cref="SearchKeyResponse"/> objects.
/// <remarks>
/// <list type="bullet">
/// <item>Usable via reflection only.</item>
/// </list>
/// </remarks>
/// </summary>
public sealed class SearchKeyMappingProfiler : Profile
{
    /// <summary>
    /// Initializes a new instance of <see cref="SearchKeyMappingProfiler"/>.
    /// <remarks>
    /// <list type="bullet">
    /// <item>Usable via reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    public SearchKeyMappingProfiler()
    {
        CreateMap<SearchKey, SearchKeyResponse>()
            .ForMember(dest => dest.Id, exp => exp.MapFrom(src => src.Id));
    }
}