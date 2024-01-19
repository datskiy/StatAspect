// ReSharper disable UnusedType.Global

using StatAspect.Application._Common.Pipelines.Responses;
using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain._Common.Aggregates;
using StatAspect.Domain._Common.ValueObjects;
using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Repositories;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a <see cref="GetSearchKeysQuery"/> handler.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class GetSearchKeysHandler : IRequestHandler<GetSearchKeysQuery, PipelineResponse<IImmutableList<SearchKey>>>
{
    private readonly ISearchKeyQueryRepository _searchKeyQueryRepository;

    public GetSearchKeysHandler(ISearchKeyQueryRepository searchKeyQueryRepository)
    {
        _searchKeyQueryRepository = searchKeyQueryRepository;
    }

    /// <summary>
    /// Handles the <see cref="GetSearchKeysQuery"/>.
    /// <remarks>Reflection usage only.</remarks>
    /// </summary>
    public async Task<PipelineResponse<IImmutableList<SearchKey>>> Handle(GetSearchKeysQuery query, CancellationToken cancellationToken)
    {
        var selectionParams = BuildSelectionParams(query);
        var result = await _searchKeyQueryRepository.GetAllAsync(selectionParams, cancellationToken);

        return new PipelineResponse<IImmutableList<SearchKey>>(result);
    }

    private static SelectionParams BuildSelectionParams(GetSearchKeysQuery query)
    {
        return new SelectionParams(
            new SelectionOffset(query.Offset),
            new SelectionLimit(query.Limit));
    }
}