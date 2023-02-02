using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.SharedKernel.Aggregates;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a search keys read request handler.
/// <remarks>
/// <list type="bullet">
/// <item>Usable via reflection only.</item>
/// </list>
/// </remarks>
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
    /// <remarks>
    /// <list type="bullet">
    /// <item>Usable via reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<IImmutableList<SearchKey>> Handle(GetSearchKeysQuery request, CancellationToken cancellationToken)
    {
        Guard.Argument(() => request).NotNull();

        var selectionParams = new SelectionParams(request.Offset, request.Limit);
        return _searchKeyQueryRepository.ReadMultipleAsync(selectionParams, cancellationToken);
    }
}