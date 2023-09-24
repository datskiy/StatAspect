// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain._Common.Aggregates;
using StatAspect.Domain._Common.ValueObjects;
using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Repositories;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a search keys getting request handler.
/// <remarks>Reflection only.</remarks>
/// </summary>
public sealed class GetSearchKeysHandler : IRequestHandler<GetSearchKeysQuery, IImmutableList<SearchKey>>
{
    private readonly ISearchKeyQueryRepository _searchKeyQueryRepository;

    public GetSearchKeysHandler(ISearchKeyQueryRepository searchKeyQueryRepository)
    {
        _searchKeyQueryRepository = searchKeyQueryRepository;
    }

    /// <summary>
    /// Returns a result of processing the <see cref="GetSearchKeysQuery"/> request.
    /// <remarks>Reflection only.</remarks>
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<IImmutableList<SearchKey>> Handle(GetSearchKeysQuery query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query);

        var selectionParams = new SelectionParams(
            new SelectionOffset(query.Offset),
            new SelectionLimit(query.Limit));

        return _searchKeyQueryRepository.GetAllAsync(selectionParams, cancellationToken);
    }
}