using StatAspect.Domain.MediaTracking.ValueObjects;

namespace StatAspect.Domain.MediaTracking.Aggregates;

/// <summary>
/// Represents a new search key.
/// </summary>
public sealed class NewSearchKey
{
    /// <summary>
    /// Gets a new search key name.
    /// </summary>
    public SearchKeyName Name { get; }

    /// <summary>
    /// Gets a new search key description.
    /// </summary>
    public SearchKeyDescription? Description { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="NewSearchKey"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public NewSearchKey(SearchKeyName name, SearchKeyDescription? description)
    {
        ArgumentNullException.ThrowIfNull(name);

        Name = name;
        Description = description;
    }
}