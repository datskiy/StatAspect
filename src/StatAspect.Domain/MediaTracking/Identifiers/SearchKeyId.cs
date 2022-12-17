using StatAspect.Domain.MediaTracking.Identifiers.Abstractions;

namespace StatAspect.Domain.MediaTracking.Identifiers;

/// <summary>
/// Represents a search key unique identifier.
/// </summary>
public sealed record SearchKeyId : ObjectId
{
    /// <summary>
    /// Initializes a new instance of <see cref="SearchKeyId"/>.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public SearchKeyId(int value) : base(value)
    {
    }
}