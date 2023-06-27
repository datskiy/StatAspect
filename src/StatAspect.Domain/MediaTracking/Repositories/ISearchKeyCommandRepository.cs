using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Domain.MediaTracking.Repositories;

/// <summary>
/// Represents a search key command repository.
/// </summary>
public interface ISearchKeyCommandRepository // TODO: implement
{
    /// <summary>
    /// Adds a new search key entity.
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="DbException"/>
    /// </summary>
    Task<SearchKeyId> AddAsync(NewSearchKey newSearchKey);

    /// <summary>
    /// Updates a search key entity.
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="DbException"/>
    /// </summary>
    Task<Success> UpdateAsync(ModifiedSearchKey modifiedSearchKey);

    /// <summary>
    /// Deletes a search key entity.
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="DbException"/>
    /// </summary>
    Task<Success> DeleteAsync(SearchKeyId id);
}