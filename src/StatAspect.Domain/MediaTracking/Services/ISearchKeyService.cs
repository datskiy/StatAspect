using StatAspect.Domain.MediaTracking.Identifiers;
using StatAspect.Domain.MediaTracking.ValueObjects;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Domain.MediaTracking.Services;

/// <summary>
/// XXX
/// </summary>
public interface ISearchKeyService
{
    /// <summary>
    /// XXX
    /// </summary>
    Task<OneOf<SearchKeyId, AlreadyExists>> AddAsync(NewSearchKey newSearchKey);

    /// <summary>
    /// XXX
    /// </summary>
    Task<OneOf<Success, NotFound, AlreadyExists>> UpdateAsync(ModifiedSearchKey modifiedSearchKey);

    /// <summary>
    /// XXX
    /// </summary>
    Task<OneOf<Success, NotFound>> DeleteAsync(SearchKeyId id);
}