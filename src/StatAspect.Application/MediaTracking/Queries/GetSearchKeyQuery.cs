using StatAspect.Domain.MediaTracking.Aggregates;

namespace StatAspect.Application.MediaTracking.Queries;

/// <summary>
/// Represents a query for getting a specified search key.
/// </summary>
public sealed class GetSearchKeyQuery : IRequest<SearchKey?>
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