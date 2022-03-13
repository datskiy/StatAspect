using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain.MediaTracking.ValueObjects;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a search key read request handler.
/// </summary>
public sealed class GetSearchKeysHandler : IRequestHandler<GetSearchKeysQuery, IImmutableList<SearchKey>>
{
    /// <summary>
    /// Returns a result of processing the <see cref="GetSearchKeysQuery"/> request.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<IImmutableList<SearchKey>> Handle(GetSearchKeysQuery request, CancellationToken cancellationToken)
    {
        Guard.Argument(() => request).NotNull();

        return Task.FromResult<IImmutableList<SearchKey>>(ImmutableList.Create(
            new SearchKey(1, "Sport", "Something realated to sport all around the world", DateTime.Now, null),
            new SearchKey(2, "Russian invades", "Russian invasion metrics", DateTime.Now.AddDays(-7), DateTime.Now)));
    }
}