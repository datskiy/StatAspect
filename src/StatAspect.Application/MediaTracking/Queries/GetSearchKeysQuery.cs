using StatAspect.Domain.MediaTracking.ValueObjects;

namespace StatAspect.Application.MediaTracking.Queries;

/// <summary>
/// Represents a query that performs a multiple search keys read operation.
/// </summary>
public sealed class GetSearchKeysQuery : IRequest<IImmutableList<SearchKey>>
{
    /// <summary>
    /// Gets the offset of the search key collection first item to return.
    /// </summary>
    public int Offset { get; }

    /// <summary>
    /// Gets the maximum number of the search key collection entries to return.
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