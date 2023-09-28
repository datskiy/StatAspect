using StatAspect.Domain._Common.Aggregates;
using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.Domain.MediaTracking.ValueObjects;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

namespace StatAspect.Infrastructure.MediaTracking.Repositories.Implementations;

public sealed class SearchKeyQueryRepository : ISearchKeyQueryRepository
{
    public Task<SearchKey?> GetSingleAsync(SearchKeyId id, CancellationToken cancellationToken = default) // TODO: implement
    {
        ArgumentNullException.ThrowIfNull(id);

        return Task.FromResult<SearchKey?>(new SearchKey(new SearchKeyId(Guid.NewGuid()), new SearchKeyName("XXX"), new SearchKeyDescription("Xxx xxx xxx"), DateTime.Now, null)); // TODO: implement
    }

    public Task<IImmutableList<SearchKey>> GetAllAsync(SelectionParams selectionParams, CancellationToken cancellationToken = default)  // TODO: implement
    {
        ArgumentNullException.ThrowIfNull(selectionParams);

        return Task.FromResult<IImmutableList<SearchKey>>(ImmutableList.Create(
            new SearchKey(new SearchKeyId(Guid.NewGuid()), new SearchKeyName("Qwe"), new SearchKeyDescription("QWeq qweqwe"), DateTime.Now, null),
            new SearchKey(new SearchKeyId(Guid.NewGuid()), new SearchKeyName("Zxc"), new SearchKeyDescription("Z X C"), DateTime.Now.AddDays(-7), DateTime.Now)));
    }

    public Task<bool> ExistsAsync(SearchKeyId id, CancellationToken cancellationToken = default)  // TODO: implement
    {
        ArgumentNullException.ThrowIfNull(id);

        return Task.FromResult(true);
    }

    public Task<bool> ExistsAsync(SearchKeyName name, CancellationToken cancellationToken = default)  // TODO: implement
    {
        ArgumentNullException.ThrowIfNull(name);

        return Task.FromResult(false);
    }
}