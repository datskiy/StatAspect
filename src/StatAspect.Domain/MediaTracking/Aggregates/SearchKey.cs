using StatAspect.Domain.MediaTracking.ValueObjects;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

namespace StatAspect.Domain.MediaTracking.Aggregates;

/// <summary>
/// Represents a search key.
/// </summary>
public sealed class SearchKey
{
    /// <summary>
    /// Gets a unique search key identifier.
    /// </summary>
    public SearchKeyId Id { get; }

    /// <summary>
    /// Gets a search key name.
    /// </summary>
    public SearchKeyName Name { get; }

    /// <summary>
    /// Gets a search key description.
    /// </summary>
    public SearchKeyDescription? Description { get; }

    /// <summary>
    /// Gets a search key creation date.
    /// </summary>
    public DateTime CreationDate { get; } // TODO: validate?

    /// <summary>
    /// Gets a search key last update date.
    /// </summary>
    public DateTime? LastUpdateDate { get; } // TODO: validate?

    /// <summary>
    /// Initializes a new instance of <see cref="SearchKey"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public SearchKey(
        SearchKeyId id,
        SearchKeyName name,
        SearchKeyDescription? description,
        DateTime creationDate,
        DateTime? lastUpdateDate)
    {
        ArgumentNullException.ThrowIfNull(name);

        Id = id;
        Name = name;
        Description = description;
        CreationDate = creationDate;
        LastUpdateDate = lastUpdateDate;
    }
}