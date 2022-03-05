using StatAspect.Api.MediaTracking.Models.Responses;
using StatAspect.Domain.MediaTracking.ValueObjects;

namespace StatAspect.Api.MediaTracking.MappingProfilers;

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