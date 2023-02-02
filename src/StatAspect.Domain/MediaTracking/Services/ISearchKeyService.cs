using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.Results;
using StatAspect.SharedKernel.Results.Properties;

namespace StatAspect.Domain.MediaTracking.Services;

/// <summary>
/// Represents a search key service.
/// </summary>
public interface ISearchKeyService
{
    /// <summary>
    /// Adds a new search key.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    Task<OneOf<SearchKeyId, AlreadyExists<Name>>> AddAsync(NewSearchKey newSearchKey);

    /// <summary>
    /// Updates a search key.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    Task<OneOf<Success, NotFound, AlreadyExists<Name>>> UpdateAsync(ModifiedSearchKey modifiedSearchKey);

    /// <summary>
    /// Deletes a search key.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    Task<OneOf<Success, NotFound>> DeleteAsync(SearchKeyId id);
}