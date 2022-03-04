using StatAspect.Api.Models.Responses.MediaTracking;
using StatAspect.Domain.ValueObjects.MediaTracking;

namespace StatAspect.Api.MappingProfilers.MediaTracking;

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