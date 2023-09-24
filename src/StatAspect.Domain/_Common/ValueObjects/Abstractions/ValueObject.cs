namespace StatAspect.Domain._Common.ValueObjects.Abstractions;

/// <summary>
/// TODO: description
/// </summary>
public abstract record ValueObject<T>
{
    private readonly T _value;

    protected ValueObject(T value, IValidator<T> validator)
    {
        ArgumentNullException.ThrowIfNull(value);
        ArgumentNullException.ThrowIfNull(validator);

        var validationResult = validator.Validate(value);
        if (!validationResult.IsValid)
            throw new ArgumentException(string.Join(", ", validationResult.Errors));

        _value = value;
    }

    public sealed override string ToString()
    {
        return $"{_value}";
    }

    public static implicit operator T(ValueObject<T> obj) => obj._value;
}