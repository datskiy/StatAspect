﻿using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.Aggregates;

namespace StatAspect.Domain.MediaTracking.Repositories;

/// <summary>
/// XXX
/// </summary>
public interface ISearchKeyQueryRepository// TODO: implement
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