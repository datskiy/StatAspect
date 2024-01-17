// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a <see cref="GetSearchKeyQuery"/> handler.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class GetSearchKeyHandler : IRequestHandler<GetSearchKeyQuery, SearchKey?>
{
    private readonly ISearchKeyQueryRepository _searchKeyQueryRepository;

    public GetSearchKeyHandler(ISearchKeyQueryRepository searchKeyQueryRepository)
    {
        _searchKeyQueryRepository = searchKeyQueryRepository;
    }

    /// <summary>
    /// Handles the <see cref="GetSearchKeyQuery"/>.
    /// <remarks>Reflection usage only.</remarks>
    /// </summary>
    public Task<SearchKey?> Handle(GetSearchKeyQuery query, CancellationToken cancellationToken)
    {
        var targetSearchKeyId = new SearchKeyId(query.Id);
        return _searchKeyQueryRepository.GetSingleAsync(targetSearchKeyId, cancellationToken);
    }
}