﻿using StatAspect.Domain.MediaTracking.ValueObjects;

namespace StatAspect.Application.MediaTracking.Queries;

/// <summary>
/// Represents a query that performs a specific search key read operation.
/// </summary>
public sealed class GetSearchKeyQuery : IRequest<SearchKey?>
{
    /// <summary>
    /// Gets a target search key identifier.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Initializes a new <see cref="GetSearchKeyQuery"/> instance.
    /// </summary>
    public GetSearchKeyQuery(int id)
    {
        Id = id;
    }
}