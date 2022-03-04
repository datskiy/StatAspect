using StatAspect.Domain.ValueObjects.MediaTracking;

namespace StatAspect.Application.Queries.MediaTracking;

/// <summary>
/// Represents a query that performs a multiple search keys read operation.
/// </summary>
public sealed class GetSearchKeysQuery : IRequest<IImmutableList<SearchKey>>
{
    /// <summary>
    /// Initializes a new <see cref="GetSearchKeysQuery"/> instance.
    /// </summary>
    public GetSearchKeysQuery()
    {
    }// todo: paging, filtering, sorting
}