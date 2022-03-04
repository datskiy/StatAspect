using StatAspect.Api.Interaction.Responses.MediaTracking;
using StatAspect.Domain.ValueObjects.MediaTracking;

namespace StatAspect.Api.Mapping.MediaTracking;

/// <summary>
/// Represent a mapping configuration provider for <see cref="SearchKey"/>.
/// </summary>
public sealed class SearchKeyProfiler : Profile
{
    public SearchKeyProfiler()
    {
        CreateMap<SearchKey, SearchKeyResponse>();
    }
}