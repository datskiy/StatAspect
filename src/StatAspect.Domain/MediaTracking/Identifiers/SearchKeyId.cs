namespace StatAspect.Domain.MediaTracking.Identifiers;

/// <summary>
/// Represents a search key unique identifier.
/// </summary>
public sealed record SearchKeyId // todo: inherit from base
{
    /// <summary>
    /// Gets the value of the identifier.
    /// </summary>
    public int Value { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="SearchKeyId"/>.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public SearchKeyId(int value)
    {
        Guard.Argument(() => value).GreaterThan(default);

        Value = value;
    }
}