// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.SharedKernel.Aggregates;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a search keys getting request handler.
/// <remarks>
/// <list type="bullet">
/// <item>Reflection only.</item>
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
    /// <item>Reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<IImmutableList<SearchKey>> Handle(GetSearchKeysQuery query, CancellationToken cancellationToken)
    {
        Guard.Argument(() => query).NotNull();

        var selectionParams = new SelectionParams(query.Offset, query.Limit);
        return _searchKeyQueryRepository.GetAllAsync(selectionParams, cancellationToken);
    }
}