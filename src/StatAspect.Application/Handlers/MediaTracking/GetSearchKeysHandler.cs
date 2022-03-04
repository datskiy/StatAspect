using StatAspect.Application.Queries.MediaTracking;
using StatAspect.Domain.ValueObjects.MediaTracking;

namespace StatAspect.Application.Handlers.MediaTracking;

/// <summary>
/// Represents a search key read request handler.
/// </summary>
public sealed class GetSearchKeysHandler : IRequestHandler<GetSearchKeysQuery, IList<SearchKey>>
{
    /// <summary>
    /// Returns the result of processing the <see cref="GetSearchKeysQuery"/> request.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<IList<SearchKey>> Handle(GetSearchKeysQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult<IList<SearchKey>>(new List<SearchKey>
        {
            new SearchKey(1, "China attacks", "The main news from China attacks Kazakhstan", DateTime.Now, null),
            new SearchKey(2, "Russian", "Russian invasion metrics", DateTime.Now.AddDays(-7), DateTime.Now)
        });
    }
}