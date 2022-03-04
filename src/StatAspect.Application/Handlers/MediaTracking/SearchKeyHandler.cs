using StatAspect.Application.Queries.MediaTracking;
using StatAspect.Domain.ValueObjects.MediaTracking;

namespace StatAspect.Application.Handlers.MediaTracking;

/// <summary>
/// Represents search key requests handler.
/// </summary>
public class SearchKeyHandler : IRequestHandler<GetSearchKeyQuery, SearchKey?>
{
    /// <summary>
    /// Returns the result of processing the <see cref="GetSearchKeyQuery"/> request.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<SearchKey?> Handle(GetSearchKeyQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult<SearchKey?>(new SearchKey(1, "China attacks", "The main news from China attacks Kazakhstan", DateTime.Now, null));
    }
}
