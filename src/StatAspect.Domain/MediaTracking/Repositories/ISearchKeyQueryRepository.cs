using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.ValueObjects.Identitfiers;
using StatAspect.SharedKernel.Aggregates;

namespace StatAspect.Domain.MediaTracking.Repositories;

/// <summary>
/// XXX
/// </summary>
public interface ISearchKeyQueryRepository
{
    /// <summary>
    /// XXX
    /// </summary>
    Task<SearchKey?> ReadSingleAsync(SearchKeyId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// XXX
    /// </summary>
    Task<IImmutableList<SearchKey>> ReadMultipleAsync(SelectionParams selectionParams, CancellationToken cancellationToken = default);

    /// <summary>
    /// XXX
    /// </summary>
    Task<bool> ExistsAsync(SearchKeyId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// XXX
    /// </summary>
    Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default);
}