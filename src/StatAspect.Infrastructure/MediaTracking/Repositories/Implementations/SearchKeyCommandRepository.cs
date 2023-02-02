using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Infrastructure.MediaTracking.Repositories.Implementations;

public sealed class SearchKeyCommandRepository : ISearchKeyCommandRepository // todo: guards
{
    public Task<SearchKeyId> CreateAsync(NewSearchKey newSearchKey)
    {
        return Task.FromResult(new SearchKeyId(Guid.NewGuid())); //todo: implement
    }

    public Task<Success> UpdateAsync(ModifiedSearchKey modifiedSearchKey)
    {
        return Task.FromResult(new Success()); //todo: implement
    }

    public Task<Success> DeleteAsync(SearchKeyId id)
    {
        return Task.FromResult(new Success()); //todo: implement
    }
}