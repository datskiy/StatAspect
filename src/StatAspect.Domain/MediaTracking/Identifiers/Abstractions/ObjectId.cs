namespace StatAspect.Domain.MediaTracking.Identifiers.Abstractions;

/// <summary>
/// Represents a base object unique identifier.
/// </summary>
public abstract record ObjectId
{
    private readonly int _value;

    /// <exception cref="ArgumentOutOfRangeException"/>
    protected ObjectId(int value)
    {
        Guard.Argument(() => value).GreaterThan(default);

        _value = value;
    }

    public static explicit operator int(ObjectId id) => id._value;
}