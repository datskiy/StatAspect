using StatAspect.Domain.MediaTracking.Aggregates;

namespace StatAspect.Application.MediaTracking.Queries;

/// <summary>
/// Represents a query for getting filtered search keys.
/// </summary>
public sealed class GetSearchKeysQuery : IRequest<IImmutableList<SearchKey>>
{
    /// <summary>
    /// Gets an offset of the first search key entry to return.
    /// </summary>
    public int Offset { get; }

    /// <summary>
    /// Gets a number limit of search key entries to return.
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