using StatAspect.Domain.MediaTracking.Identifiers;
using StatAspect.Domain.MediaTracking.ValueObjects;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Domain.MediaTracking.Repositories;

/// <summary>
/// XXX
/// </summary>
public interface ISearchKeyCommandRepository
{
    /// <summary>
    /// XXX
    /// </summary>
    Task<SearchKeyId> CreateAsync(NewSearchKey newSearchKey);

    /// <summary>
    /// XXX
    /// </summary>
    Task<Success> UpdateAsync(ModifiedSearchKey modifiedSearchKey);

    /// <summary>
    /// XXX
    /// </summary>
    Task<Success> DeleteAsync(SearchKeyId id);
}