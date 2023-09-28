using StatAspect.Domain.MediaTracking.ValueObjects;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

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
    /// Gets a modified search key name.
    /// </summary>
    public SearchKeyName Name { get; }

    /// <summary>
    /// Gets a modified search key description.
    /// </summary>
    public SearchKeyDescription? Description { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="ModifiedSearchKey"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public ModifiedSearchKey(
        SearchKeyId id,
        SearchKeyName name,
        SearchKeyDescription? description)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(name);

        Id = id;
        Name = name;
        Description = description;
    }
}