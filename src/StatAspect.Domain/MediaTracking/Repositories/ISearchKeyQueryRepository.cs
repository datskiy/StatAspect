using StatAspect.Domain._Common.Aggregates;
using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.ValueObjects;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

namespace StatAspect.Domain.MediaTracking.Repositories;

/// <summary>
/// Represents a search key query repository.
/// </summary>
public interface ISearchKeyQueryRepository// TODO: implement
{
    /// <summary>
    /// Returns the only search key entity that corresponds the specified identifier, otherwise returns null.
    /// Throws an exception if there is more than one element found.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    Task<SearchKey?> GetSingleAsync(SearchKeyId id, CancellationToken cancellationToken = default); // TODO: rename

    /// <summary>
    /// Returns a list of search key entities filtered by the specified selection parameters.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    Task<IImmutableList<SearchKey>> GetAllAsync(SelectionParams selectionParams, CancellationToken cancellationToken = default);

    /// <summary>
    /// Determines whether there are any search key entities that match the specified identifier.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    Task<bool> ExistsAsync(SearchKeyId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Determines whether there are any search key entities that match the specified name.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    Task<bool> ExistsAsync(SearchKeyName name, CancellationToken cancellationToken = default);
}