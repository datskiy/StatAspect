namespace StatAspect.Domain.General.ValueObjects.Abstractions.Identifiers;

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

    public sealed override string ToString()
    {
        return $"{_value}";
    }

    public static explicit operator int(ObjectId id) => id._value;
}