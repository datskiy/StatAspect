using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain.MediaTracking.ValueObjects;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a search key read request handler.
/// </summary>
public sealed class GetSearchKeyHandler : IRequestHandler<GetSearchKeyQuery, SearchKey?>
{
    /// <summary>
    /// Returns a result of processing the <see cref="GetSearchKeyQuery"/> request.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<SearchKey?> Handle(GetSearchKeyQuery request, CancellationToken cancellationToken)
    {
        Guard.Argument(() => request).NotNull();

        return Task.FromResult<SearchKey?>(new SearchKey(1, "Urgent", "The main news of the Earch", DateTime.Now, null));
    }
}