using StatAspect.Api.MediaTracking.Models.Responses;
using StatAspect.Domain.MediaTracking.ValueObjects;

namespace StatAspect.Api.MediaTracking.Profilers;

/// <summary>
/// Represents a mapping configuration profile for <see cref="SearchKey"/>.
/// </summary>
public sealed class SearchKeyProfiler : Profile
{
    public SearchKeyProfiler()
    {
        CreateMap<SearchKey, SearchKeyResponse>();
    }
}