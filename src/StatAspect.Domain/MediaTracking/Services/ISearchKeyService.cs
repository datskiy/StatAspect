using StatAspect.Domain.MediaTracking.Identifiers;
using StatAspect.Domain.MediaTracking.ValueObjects;
using StatAspect.SharedKernel.Results;
using StatAspect.SharedKernel.Results.Properties;

namespace StatAspect.Domain.MediaTracking.Services;

/// <summary>
/// XXX
/// </summary>
public interface ISearchKeyService
{
    /// <summary>
    /// XXX
    /// </summary>
    Task<OneOf<SearchKeyId, AlreadyExists<Name>>> AddAsync(NewSearchKey newSearchKey);

    /// <summary>
    /// XXX
    /// </summary>
    Task<OneOf<Success, NotFound, AlreadyExists<Name>>> UpdateAsync(ModifiedSearchKey modifiedSearchKey);

    /// <summary>
    /// XXX
    /// </summary>
    Task<OneOf<Success, NotFound>> DeleteAsync(SearchKeyId id);
}