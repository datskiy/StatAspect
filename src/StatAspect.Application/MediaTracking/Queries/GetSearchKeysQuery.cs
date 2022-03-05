﻿using StatAspect.Domain.MediaTracking.ValueObjects;

namespace StatAspect.Application.MediaTracking.Queries;

/// <summary>
/// Represents a query that performs a multiple search keys read operation.
/// </summary>
public sealed class GetSearchKeysQuery : IRequest<IImmutableList<SearchKey>>
{
    /// <summary>
    /// Initializes a new <see cref="GetSearchKeysQuery"/> instance.
    /// </summary>
    public GetSearchKeysQuery()
    {
    }// todo: paging, filtering, sorting
}