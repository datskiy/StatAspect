using StatAspect.Domain._Common.ValueObjects.Abstractions;

namespace StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

/// <summary>
/// Represents a unique search key identifier.
/// </summary>
public sealed record SearchKeyId : ValueIdentity
{
    /// <summary>
    /// Initializes a new instance of <see cref="SearchKeyId"/>.
    /// </summary>
    /// <exception cref="ArgumentException"/>
    public SearchKeyId(Guid value) : base(value, nameof(SearchKeyId))
    {
    }
}