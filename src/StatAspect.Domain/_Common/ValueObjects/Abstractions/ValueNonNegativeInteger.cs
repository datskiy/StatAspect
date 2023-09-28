using StatAspect.Domain._Common.Validators;

namespace StatAspect.Domain._Common.ValueObjects.Abstractions;

/// <summary>
/// Represents an abstract non-negative integer value object.
/// </summary>
public abstract record ValueNonNegativeInteger : ValueObject<int>, IIntegrityEnsurer<int>
{
    /// <summary>
    /// Initializes a new instance of <see cref="ValueNonNegativeInteger"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    protected ValueNonNegativeInteger(int value, string paramName) : base(value, GetValidator(paramName))
    {
        ArgumentNullException.ThrowIfNull(paramName);
    }

    public static IValidator<int> GetValidator(string? paramName = null)
    {
        return new NonNegativeIntegerValidator(paramName ?? nameof(ValueNonNegativeInteger));
    }
}