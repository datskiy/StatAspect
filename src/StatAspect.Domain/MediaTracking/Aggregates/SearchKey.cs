using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

namespace StatAspect.Domain.MediaTracking.Aggregates;

/// <summary>
/// Represents a search key.
/// </summary>
public sealed class SearchKey
{
    /// <summary>
    /// Gets a unique identifier for the current search key.
    /// </summary>
    public SearchKeyId Id { get; }

    /// <summary>
    /// Gets the name of the search key.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the description of the search key.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the date the current search key was created.
    /// </summary>
    public DateTime CreationDate { get; }

    /// <summary>
    /// Gets the date the current search key was last updated.
    /// </summary>
    public DateTime? LastUpdateDate { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="SearchKey"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public SearchKey(
        Guid id,
        string name,
        string? description,
        DateTime creationDate,
        DateTime? lastUpdateDate)
    {
        Guard.Argument(() => name).NotNull();

        Id = new SearchKeyId(id);
        Name = name;
        Description = description;
        CreationDate = creationDate;
        LastUpdateDate = lastUpdateDate;
    }
}