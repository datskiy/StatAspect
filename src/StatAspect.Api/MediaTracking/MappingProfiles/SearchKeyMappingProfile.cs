// ReSharper disable UnusedType.Global

using StatAspect.Api.MediaTracking.Models.Responses;
using StatAspect.Domain.MediaTracking.Aggregates;

namespace StatAspect.Api.MediaTracking.MappingProfiles;

/// <summary>
/// Represents a mapping configuration profile between <see cref="SearchKey"/> and <see cref="SearchKeyResponseBody"/>.
/// <remarks>Used only through reflection.</remarks>
/// </summary>
public sealed class SearchKeyMappingProfile : Profile
{
    public SearchKeyMappingProfile()
    {
        CreateMap<SearchKey, SearchKeyResponseBody>();
    }
}