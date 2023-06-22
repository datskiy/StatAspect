using StatAspect.Domain._Common.ValueObjects.Abstractions.Identifiers;

namespace StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

/// <summary>
/// Represents a search key unique identifier.
/// </summary>
public sealed record SearchKeyId : ObjectId
{
    /// <summary>
    /// Initializes a new instance of <see cref="SearchKeyId"/>.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public SearchKeyId(Guid value) : base(value)
    {
    }
}