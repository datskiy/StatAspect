using StatAspect.Domain.MediaTracking.Identifiers;
using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.Domain.MediaTracking.ValueObjects;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Infrastructure.MediaTracking.Repositories.Implementations;

public sealed class SearchKeyCommandRepository : ISearchKeyCommandRepository
{
    public Task<SearchKeyId> CreateAsync(NewSearchKey newSearchKey)
    {
        return Task.FromResult(new SearchKeyId(777)); //todo: implement
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