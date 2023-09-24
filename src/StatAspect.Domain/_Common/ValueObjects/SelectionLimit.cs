using StatAspect.Domain._Common.ValueObjects.Abstractions;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

namespace StatAspect.Domain._Common.ValueObjects;

/// <summary>
/// Represents a unique search key identifier. TODO: desc
/// </summary>
public sealed record SelectionLimit : ValuePositiveInteger
{
    /// <summary>
    /// Initializes a new instance of <see cref="SearchKeyId"/>.
    /// </summary>
    /// <exception cref="ArgumentException"/>
    public SelectionLimit(int value) : base(value, nameof(SelectionLimit))
    {
    }
}