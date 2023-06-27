using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.Aggregates;

namespace StatAspect.Infrastructure.MediaTracking.Repositories.Implementations;

public sealed class SearchKeyQueryRepository : ISearchKeyQueryRepository // TODO: guards
{
    public Task<SearchKey?> GetSingleAsync(SearchKeyId id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<SearchKey?>(new SearchKey(Guid.NewGuid(), "XXX", "Xxx xxx xxx", DateTime.Now, null)); // TODO: implement
    }

    public Task<IImmutableList<SearchKey>> GetAllAsync(SelectionParams selectionParams, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IImmutableList<SearchKey>>(ImmutableList.Create(
            new SearchKey(Guid.NewGuid(), "Qwe", "Qwe qwe qwe qwe", DateTime.Now, null),
            new SearchKey(Guid.NewGuid(), "Zxc zxc", "Zxc zxc zxc", DateTime.Now.AddDays(-7), DateTime.Now))); // TODO: implement
    }

    public Task<bool> ExistsAsync(SearchKeyId id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true); // TODO: implement
    }

    public Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(false); // TODO: implement
    }
}