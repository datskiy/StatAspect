using StatAspect.Domain._Common.ValueObjects;

namespace StatAspect.Domain._Common.Aggregates;

/// <summary>
/// Represents sequence selection parameters.
/// </summary>
public sealed class SelectionParams
{
    /// <summary>
    /// Gets a selection offset.
    /// </summary>
    public SelectionOffset Offset { get; }

    /// <summary>
    /// Gets a selection limit.
    /// </summary>
    public SelectionLimit Limit { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="SelectionParams"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public SelectionParams(SelectionOffset offset, SelectionLimit limit)
    {
        ArgumentNullException.ThrowIfNull(offset);
        ArgumentNullException.ThrowIfNull(limit);

        Offset = offset;
        Limit = limit;
    }
}