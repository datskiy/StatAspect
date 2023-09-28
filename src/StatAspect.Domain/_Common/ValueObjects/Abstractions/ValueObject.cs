namespace StatAspect.Domain._Common.ValueObjects.Abstractions;

/// <summary>
/// Represents an abstract immutable value object that encapsulates common primitives with domain-specific logic.
/// </summary>
public abstract record ValueObject<T>
{
    private readonly T _value;

    /// <summary>
    /// Initializes a new instance of <see cref="ValueObject{T}"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    protected ValueObject(T value, IValidator<T> validator)
    {
        ArgumentNullException.ThrowIfNull(value);
        ArgumentNullException.ThrowIfNull(validator);

        var validationResult = validator.Validate(value);
        if (!validationResult.IsValid)
            throw new ArgumentException(string.Join(", ", validationResult.Errors), nameof(value));

        _value = value;
    }

    public sealed override string ToString()
    {
        return $"{_value}";
    }

    public static implicit operator T(ValueObject<T> obj) => obj._value;
}