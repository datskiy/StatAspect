using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.Results;
using StatAspect.SharedKernel.Results.TargetProperties;

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

    public async Task<OneOf<SearchKeyId, AlreadyExists<Name>>> AddAsync(NewSearchKey newSearchKey)
    {
        ArgumentNullException.ThrowIfNull(newSearchKey);

        var sameNamedSearchKeyExists = await _searchKeyQueryRepository.ExistsAsync(newSearchKey.Name); // TODO: lock??? (Redis Lock)
        if (sameNamedSearchKeyExists)
            return new AlreadyExists<Name>();

        return await _searchKeyCommandRepository.AddAsync(newSearchKey);
    }

    public async Task<OneOf<Success, NotFound, AlreadyExists<Name>>> UpdateAsync(ModifiedSearchKey modifiedSearchKey)
    {
        ArgumentNullException.ThrowIfNull(modifiedSearchKey);

        var targetSearchKeyExists = await _searchKeyQueryRepository.ExistsAsync(modifiedSearchKey.Id); // TODO: lock??? (Redis Lock)
        if (!targetSearchKeyExists)
            return new NotFound();

        var sameNamedSearchKeyExists = await _searchKeyQueryRepository.ExistsAsync(modifiedSearchKey.Name);
        if (sameNamedSearchKeyExists)
            return new AlreadyExists<Name>();

        return await _searchKeyCommandRepository.UpdateAsync(modifiedSearchKey);
    }

    public async Task<OneOf<Success, NotFound>> DeleteAsync(SearchKeyId id)
    {
        ArgumentNullException.ThrowIfNull(id);

        var targetSearchKeyExists = await _searchKeyQueryRepository.ExistsAsync(id); // TODO: should we do the same for delete methods???
        if (!targetSearchKeyExists)
            return new NotFound();

        return await _searchKeyCommandRepository.DeleteAsync(id);
    }
}