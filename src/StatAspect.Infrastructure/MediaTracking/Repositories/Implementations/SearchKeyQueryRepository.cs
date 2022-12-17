using StatAspect.Domain.MediaTracking.Identifiers;
using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.Domain.MediaTracking.ValueObjects;
using StatAspect.SharedKernel.Aggregates;

namespace StatAspect.Infrastructure.MediaTracking.Repositories.Implementations;

public sealed class SearchKeyQueryRepository : ISearchKeyQueryRepository // todo: guards
{
    public Task<SearchKey?> ReadSingleAsync(SearchKeyId id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<SearchKey?>(new SearchKey(1, "XXX", "Xxx xxx xxx", DateTime.Now, null)); //todo: implement
    }

    public Task<IImmutableList<SearchKey>> ReadMultipleAsync(SelectionParams selectionParams, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IImmutableList<SearchKey>>(ImmutableList.Create(
            new SearchKey(1, "Qwe", "Qwe qwe qwe qwe", DateTime.Now, null),
            new SearchKey(2, "Zxc zxc", "Zxc zxc zxc", DateTime.Now.AddDays(-7), DateTime.Now))); //todo: implement
    }

    public Task<bool> ExistsAsync(SearchKeyId id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true); //todo: implement
    }

    public Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(false); //todo: implement
    }
}