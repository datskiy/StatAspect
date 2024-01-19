// ReSharper disable UnusedType.Global

using StatAspect.Application._Common.Pipelines.Responses;
using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a <see cref="GetSearchKeyQuery"/> handler.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class GetSearchKeyHandler : IRequestHandler<GetSearchKeyQuery, PipelineResponse<SearchKey?>>
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
    public async Task<PipelineResponse<SearchKey?>> Handle(GetSearchKeyQuery query, CancellationToken cancellationToken)
    {
        var targetSearchKeyId = new SearchKeyId(query.Id);
        var result = await _searchKeyQueryRepository.GetSingleAsync(targetSearchKeyId, cancellationToken);

        return new PipelineResponse<SearchKey?>(result);
    }
}