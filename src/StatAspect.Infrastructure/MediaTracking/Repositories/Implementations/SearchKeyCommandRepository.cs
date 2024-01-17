using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.OneOf.Results;

namespace StatAspect.Infrastructure.MediaTracking.Repositories.Implementations;

public sealed class SearchKeyCommandRepository : ISearchKeyCommandRepository
{
    public Task<SearchKeyId> AddAsync(NewSearchKey newSearchKey)
    {
        ArgumentNullException.ThrowIfNull(newSearchKey);

        return Task.FromResult(new SearchKeyId(Guid.NewGuid())); // TODO: implement
    }

    public Task<Success> UpdateAsync(ModifiedSearchKey modifiedSearchKey)
    {
        ArgumentNullException.ThrowIfNull(modifiedSearchKey);

        return Task.FromResult(new Success()); // TODO: implement
    }

    public Task<Success> DeleteAsync(SearchKeyId id)
    {
        ArgumentNullException.ThrowIfNull(id);

        return Task.FromResult(new Success()); // TODO: implement
    }
}