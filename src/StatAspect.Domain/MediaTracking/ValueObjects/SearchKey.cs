namespace StatAspect.Domain.MediaTracking.ValueObjects;

/// <summary>
/// Represents search key.
/// </summary>
public sealed class SearchKey
{
    /// <summary>
    /// Gets a unique identifier for the current search key.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets the name of the search key.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets the description of the search key.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets the creation date of the current search key.
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Gets the date the current search key was last updated.
    /// </summary>
    public DateTime? LastUpdateDate { get; set; }

    /// <summary>
    /// Initializes a new <see cref="SearchKey"/> instance.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public SearchKey(
        int id,
        string name,
        string? description,
        DateTime creationDate,
        DateTime? lastUpdateDate)
    {
        Guard.Argument(() => name).NotNull();

        Id = id;
        Name = name;
        Description = description;
        CreationDate = creationDate;
        LastUpdateDate = lastUpdateDate;
    }
}