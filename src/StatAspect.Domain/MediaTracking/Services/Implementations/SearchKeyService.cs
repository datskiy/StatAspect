using StatAspect.Domain.MediaTracking.Identifiers;
using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.Domain.MediaTracking.ValueObjects;
using StatAspect.SharedKernel.Markers;

namespace StatAspect.Domain.MediaTracking.Services.Implementations;

public sealed class SearchKeyService : ISearchKeyService
{
    private readonly ISearchKeyQueryRepository _searchKeyQueryRepository;
    private readonly ISearchKeyCommandRepository _searchKeyCommandRepository;

    public SearchKeyService(
        ISearchKeyQueryRepository searchKeyQueryRepository,
        ISearchKeyCommandRepository searchKeyCommandRepository)
    {
        _searchKeyQueryRepository = searchKeyQueryRepository;
        _searchKeyCommandRepository = searchKeyCommandRepository;
    }

    public async Task<OneOf<SearchKeyId, AlreadyExists>> AddAsync(NewSearchKey newSearchKey)
    {
        Guard.Argument(() => newSearchKey).NotNull();

        var sameNamedSearchKeyExists = await _searchKeyQueryRepository.ExistsAsync(newSearchKey.Name);
        if (sameNamedSearchKeyExists)
            return new AlreadyExists();

        return await _searchKeyCommandRepository.CreateAsync(newSearchKey);
    }

    public async Task<OneOf<Success, NotFound, AlreadyExists>> UpdateAsync(ModifiedSearchKey modifiedSearchKey)
    {
        Guard.Argument(() => modifiedSearchKey).NotNull();

        var targetSearchKeyExists = await _searchKeyQueryRepository.ExistsAsync(modifiedSearchKey.Id);
        if (!targetSearchKeyExists)
            return new NotFound();

        var sameNamedSearchKeyExists = await _searchKeyQueryRepository.ExistsAsync(modifiedSearchKey.Name);
        if (sameNamedSearchKeyExists)
            return new AlreadyExists();

        return await _searchKeyCommandRepository.UpdateAsync(modifiedSearchKey);
    }

    public async Task<OneOf<Success, NotFound>> DeleteAsync(SearchKeyId id)
    {
        Guard.Argument(() => id).NotNull();

        var targetSearchKeyExists = await _searchKeyQueryRepository.ExistsAsync(id);
        if (!targetSearchKeyExists)
            return new NotFound();

        return await _searchKeyCommandRepository.DeleteAsync(id);
    }
}