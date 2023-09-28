using StatAspect.Domain._Common.Validators;

namespace StatAspect.Domain._Common.ValueObjects.Abstractions;

/// <summary>
/// Represents an abstract positive integer value object.
/// </summary>
public abstract record ValuePositiveInteger : ValueObject<int>, IIntegrityEnsurer<int>
{
    /// <summary>
    /// Initializes a new instance of <see cref="ValuePositiveInteger"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    protected ValuePositiveInteger(int value, string paramName) : base(value, GetValidator(paramName))
    {
        ArgumentNullException.ThrowIfNull(paramName);
    }

    public static IValidator<int> GetValidator(string? paramName = null)
    {
        return new PositiveIntegerValidator(paramName ?? nameof(ValuePositiveInteger));
    }
}