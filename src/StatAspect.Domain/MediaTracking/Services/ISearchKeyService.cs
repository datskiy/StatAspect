using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.OneOf.Results;
using StatAspect.SharedKernel.OneOf.Results.TargetProperties;

namespace StatAspect.Domain.MediaTracking.Services;

/// <summary>
/// Defines a search key service.
/// </summary>
public interface ISearchKeyService
{
    /// <summary>
    /// Adds a search key.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    Task<OneOf<SearchKeyId, AlreadyExists<Name>>> AddAsync(NewSearchKey newSearchKey);

    /// <summary>
    /// Updates a search key.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    Task<OneOf<Success, NotFound, AlreadyExists<Name>>> UpdateAsync(ModifiedSearchKey modifiedSearchKey);

    /// <summary>
    /// Deletes a search key.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    Task<OneOf<Success, NotFound>> DeleteAsync(SearchKeyId id);
}