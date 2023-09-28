using StatAspect.Domain._Common.ValueObjects.Abstractions;

namespace StatAspect.Domain._Common.ValueObjects;

/// <summary>
/// Represents a selection limit.
/// </summary>
public sealed record SelectionLimit : ValuePositiveInteger
{
    /// <summary>
    /// Initializes a new instance of <see cref="SelectionLimit"/>.
    /// </summary>
    /// <exception cref="ArgumentException"/>
    public SelectionLimit(int value) : base(value, nameof(SelectionLimit))
    {
    }
}