using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Infrastructure.MediaTracking.Repositories.Implementations;

public sealed class SearchKeyCommandRepository : ISearchKeyCommandRepository
{
    public Task<SearchKeyId> AddAsync(NewSearchKey newSearchKey)
    {
        Guard.Argument(() => newSearchKey).NotNull();
        
        return Task.FromResult(new SearchKeyId(Guid.NewGuid())); // TODO: implement
    }

    public Task<Success> UpdateAsync(ModifiedSearchKey modifiedSearchKey)
    {
        Guard.Argument(() => modifiedSearchKey).NotNull();
        
        return Task.FromResult(new Success()); // TODO: implement
    }

    public Task<Success> DeleteAsync(SearchKeyId id)
    {
        Guard.Argument(() => id).NotNull();
        
        return Task.FromResult(new Success()); // TODO: implement
    }
}