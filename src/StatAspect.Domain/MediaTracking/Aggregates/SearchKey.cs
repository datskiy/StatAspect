using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

namespace StatAspect.Domain.MediaTracking.Aggregates;

/// <summary>
/// Represents a search key.
/// </summary>
public sealed class SearchKey
{
    /// <summary>
    /// Gets a search key unique identifier.
    /// </summary>
    public SearchKeyId Id { get; }

    /// <summary>
    /// Gets a search key name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets a search key description.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets a search key creation date.
    /// </summary>
    public DateTime CreationDate { get; }

    /// <summary>
    /// Gets a search key last update date.
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
        Guard.Argument(() => name).NotNull(); // TODO: add meta checks (rather value objects)

        Id = new SearchKeyId(id);
        Name = name;
        Description = description;
        CreationDate = creationDate;
        LastUpdateDate = lastUpdateDate;
    }
}