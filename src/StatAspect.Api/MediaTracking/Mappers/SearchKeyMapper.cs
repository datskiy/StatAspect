using StatAspect.Api.MediaTracking.Models.Responses;
using StatAspect.Domain.MediaTracking.Aggregates;

namespace StatAspect.Api.MediaTracking.Mappers;

/// <summary>
/// Provides a set of mapping methods for <see cref="SearchKey"/> objects.
/// </summary>
[Mapper]
public static partial class SearchKeyMapper
{
    /// <summary>
    /// Maps the source <see cref="SearchKey"/> object to the destination <see cref="SearchKeyResponseBody"/> object.
    /// </summary>
    /// <exception cref="NullReferenceException"/>
    public static partial SearchKeyResponseBody MapToResponseBody(this SearchKey searchKey);

    /// <summary>
    /// Maps the source sequence of <see cref="SearchKey"/> objects to the destination sequence of <see cref="SearchKeyResponseBody"/> objects.
    /// </summary>
    /// <exception cref="NullReferenceException"/>
    public static partial IEnumerable<SearchKeyResponseBody> MapToResponseBody(this IImmutableList<SearchKey> searchKeys);
}