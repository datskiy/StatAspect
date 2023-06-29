using StatAspect.Domain.MediaTracking.Aggregates;

namespace StatAspect.Application.MediaTracking.Queries;

/// <summary>
/// Represents a query for getting search keys.
/// </summary>
public sealed class GetSearchKeysQuery : IRequest<IImmutableList<SearchKey>>
{
    /// <summary>
    /// Gets a search key selection offset.
    /// </summary>
    public int Offset { get; }

    /// <summary>
    /// Gets a search key selection limit.
    /// </summary>
    public int Limit { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="GetSearchKeysQuery"/>.
    /// </summary>
    public GetSearchKeysQuery(int offset, int limit)
    {
        Offset = offset;
        Limit = limit;
    }
}