using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain.MediaTracking.Identifiers;
using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.Domain.MediaTracking.ValueObjects;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a search key read request handler.
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
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<SearchKey?> Handle(GetSearchKeyQuery request, CancellationToken cancellationToken)
    {
        Guard.Argument(() => request).NotNull();

        var searchKeyId = new SearchKeyId(request.Id);
        return _searchKeyQueryRepository.ReadSingleAsync(searchKeyId, cancellationToken);
    }
}