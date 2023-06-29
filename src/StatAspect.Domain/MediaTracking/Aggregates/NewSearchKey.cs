namespace StatAspect.Domain.MediaTracking.Aggregates;

/// <summary>
/// Represents a new search key.
/// </summary>
public sealed class NewSearchKey
{
    /// <summary>
    /// Gets a new search key name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets a new search key description.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="NewSearchKey"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public NewSearchKey(
        string name,
        string? description)
    {
        Guard.Argument(() => name).NotNull();

        Name = name;
        Description = description;
    }
}