﻿using StatAspect.Domain.ValueObjects.MediaTracking;

namespace StatAspect.Application.Queries.MediaTracking;

/// <summary>
/// Represents a query that performs a specific search key read operation.
/// </summary>
public sealed class GetSearchKeyQuery : IRequest<SearchKey?>
{
    /// <summary>
    /// Gets a target search key identifier.
    /// </summary>
    public int SearchKeyId { get; }

    public GetSearchKeyQuery(int searchKeyId)
    {
        SearchKeyId = searchKeyId;
    }
}