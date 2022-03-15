using StatAspect.Domain.MediaTracking.ValueObjects;

namespace StatAspect.Application.MediaTracking.Queries;

/// <summary>
/// Represents a query that performs a multiple search keys read operation.
/// </summary>
public sealed class GetSearchKeysQuery : IRequest<IImmutableList<SearchKey>>
{
    /// <summary>
    /// Gets the offset of the first search key entry to return.
    /// </summary>
    public int Offset { get; }

    /// <summary>
    /// Gets the maximum number of search key entries to return.
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