// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain._Common.Aggregates;
using StatAspect.Domain._Common.ValueObjects;
using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Repositories;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a <see cref="GetSearchKeysQuery"/> handler.
/// <remarks>Used only through reflection.</remarks>
/// </summary>
public sealed class GetSearchKeysHandler : IRequestHandler<GetSearchKeysQuery, IImmutableList<SearchKey>>
{
    private readonly ISearchKeyQueryRepository _searchKeyQueryRepository;

    public GetSearchKeysHandler(ISearchKeyQueryRepository searchKeyQueryRepository)
    {
        _searchKeyQueryRepository = searchKeyQueryRepository;
    }

    /// <summary>
    /// Handles the <see cref="GetSearchKeysQuery"/> request.
    /// <remarks>Used only through reflection.</remarks>
    /// </summary>
    public Task<IImmutableList<SearchKey>> Handle(GetSearchKeysQuery query, CancellationToken cancellationToken)
    {
        var selectionParams = new SelectionParams(
            new SelectionOffset(query.Offset),
            new SelectionLimit(query.Limit));

        return _searchKeyQueryRepository.GetAllAsync(selectionParams, cancellationToken);
    }
}