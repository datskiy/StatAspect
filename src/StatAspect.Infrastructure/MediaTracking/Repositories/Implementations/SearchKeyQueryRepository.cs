using StatAspect.Domain._Common.Aggregates;
using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.Domain.MediaTracking.ValueObjects;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

namespace StatAspect.Infrastructure.MediaTracking.Repositories.Implementations;

public sealed class SearchKeyQueryRepository : ISearchKeyQueryRepository // TODO: guards
{
    public Task<SearchKey?> GetSingleAsync(SearchKeyId id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<SearchKey?>(new SearchKey(new SearchKeyId(Guid.NewGuid()), new SearchKeyName("XXX"), new SearchKeyDescription("Xxx xxx xxx"), DateTime.Now, null)); // TODO: implement
    }

    public Task<IImmutableList<SearchKey>> GetAllAsync(SelectionParams selectionParams, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IImmutableList<SearchKey>>(ImmutableList.Create(
            new SearchKey(new SearchKeyId(Guid.NewGuid()), new SearchKeyName("Qwe"), new SearchKeyDescription("QWeq qweqwe"), DateTime.Now, null),
            new SearchKey(new SearchKeyId(Guid.NewGuid()), new SearchKeyName("Zxc"), new SearchKeyDescription("Z X C"), DateTime.Now.AddDays(-7), DateTime.Now))); // TODO: implement
    }

    public Task<bool> ExistsAsync(SearchKeyId id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true); // TODO: implement
    }

    public Task<bool> ExistsAsync(SearchKeyName name, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(false); // TODO: implement
    }
}