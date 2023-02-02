using StatAspect.Domain.MediaTracking.ValueObjects.Identitfiers;

namespace StatAspect.Domain.MediaTracking.Aggregates;

/// <summary>
/// Represents a modified search key.
/// </summary>
public sealed class ModifiedSearchKey
{
    /// <summary>
    /// Gets the target search key identifier.
    /// </summary>
    public SearchKeyId Id { get; }

    /// <summary>
    /// Gets the modified name of the search key.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the modified description of the search key.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="ModifiedSearchKey"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public ModifiedSearchKey(
        Guid id,
        string name,
        string? description)
    {
        Guard.Argument(() => name).NotNull();

        Id = new SearchKeyId(id);
        Name = name;
        Description = description;
    }
}