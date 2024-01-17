using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.OneOf.Results;

namespace StatAspect.Domain.MediaTracking.Repositories;

/// <summary>
/// Defines a search key command repository.
/// </summary>
public interface ISearchKeyCommandRepository
{
    /// <summary>
    /// Adds a search key entry.
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="DbException"/>
    /// </summary>
    Task<SearchKeyId> AddAsync(NewSearchKey newSearchKey);

    /// <summary>
    /// Updates a search key entry.
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="DbException"/>
    /// </summary>
    Task<Success> UpdateAsync(ModifiedSearchKey modifiedSearchKey);

    /// <summary>
    /// Deletes a search key entry.
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="DbException"/>
    /// </summary>
    Task<Success> DeleteAsync(SearchKeyId id);
}