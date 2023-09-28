using StatAspect.Domain._Common.ValueObjects.Abstractions;

namespace StatAspect.Domain._Common.ValueObjects;

/// <summary>
/// Represents a selection offset.
/// </summary>
public sealed record SelectionOffset : ValueNonNegativeInteger
{
    /// <summary>
    /// Initializes a new instance of <see cref="SelectionOffset"/>.
    /// </summary>
    /// <exception cref="ArgumentException"/>
    public SelectionOffset(int value) : base(value, nameof(SelectionOffset))
    {
    }
}