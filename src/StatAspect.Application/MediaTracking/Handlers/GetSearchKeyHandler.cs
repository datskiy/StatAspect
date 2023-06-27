// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a search key getting request handler.
/// <remarks>
/// <list type="bullet">
/// <item>Reflection only.</item>
/// </list>
/// </remarks>
/// </summary>
public sealed class GetSearchKeyHandler : IRequestHandler<GetSearchKeyQuery, SearchKey?>
{
    private readonly ISearchKeyQueryRepository _searchKeyQueryRepository;

    public GetSearchKeyHandler(ISearchKeyQueryRepository searchKeyQueryRepository)
    {
        _searchKeyQueryRepository = searchKeyQueryRepository;
    }

    /// <summary>
    /// Returns a result of processing the <see cref="GetSearchKeyQuery"/> request.
    /// <remarks>
    /// <list type="bullet">
    /// <item>Reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<SearchKey?> Handle(GetSearchKeyQuery query, CancellationToken cancellationToken)
    {
        Guard.Argument(() => query).NotNull();

        var searchKeyId = new SearchKeyId(query.Id);
        return _searchKeyQueryRepository.GetSingleAsync(searchKeyId, cancellationToken);
    }
}