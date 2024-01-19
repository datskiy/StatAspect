using StatAspect.Application._Common.Pipelines.Responses;
using StatAspect.Domain.MediaTracking.Aggregates;

namespace StatAspect.Application.MediaTracking.Queries;

/// <summary>
/// Represents a search key query.
/// </summary>
public sealed class GetSearchKeyQuery : IRequest<PipelineResponse<SearchKey?>>
{
    /// <summary>
    /// Gets the target search key identifier.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="GetSearchKeyQuery"/>.
    /// </summary>
    public GetSearchKeyQuery(Guid id)
    {
        Id = id;
    }
}