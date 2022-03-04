namespace StatAspect.Domain.ValueObjects.MediaTracking;

/// <summary>
/// Represents a new search key.
/// </summary>
public sealed class NewSearchKey
{
    /// <summary>
    /// Gets the name of the new search key.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets the description of the new search key.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Initializes a new <see cref="NewSearchKey"/> instance.
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