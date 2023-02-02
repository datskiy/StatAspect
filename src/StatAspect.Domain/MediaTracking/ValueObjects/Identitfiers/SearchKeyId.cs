using StatAspect.Domain.General.ValueObjects.Abstractions.Identifiers;

namespace StatAspect.Domain.MediaTracking.ValueObjects.Identitfiers;

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