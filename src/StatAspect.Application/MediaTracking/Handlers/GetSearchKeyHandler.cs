using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.Domain.MediaTracking.ValueObjects.Identitfiers;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a search key read request handler.
/// <remarks>
/// <list type="bullet">
/// <item>Usable via reflection only.</item>
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
    /// <item>Usable via reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    public Task<SearchKey?> Handle(GetSearchKeyQuery request, CancellationToken cancellationToken)
    {
        var searchKeyId = new SearchKeyId(request.Id);
        return _searchKeyQueryRepository.ReadSingleAsync(searchKeyId, cancellationToken);
    }
}