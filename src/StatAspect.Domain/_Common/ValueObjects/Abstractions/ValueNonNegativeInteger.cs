using StatAspect.Domain._Common.Validators;

namespace StatAspect.Domain._Common.ValueObjects.Abstractions;

/// <summary>
/// TODO: description
/// </summary>
public abstract record ValueNonNegativeInteger : ValueObject<int>, IIntegrityObject<int>
{
    /// <summary>
    /// Initializes a new instance of <see cref="ValueNonNegativeInteger"/>.
    /// </summary>
    /// <exception cref="ArgumentException"/>
    protected ValueNonNegativeInteger(int value, string paramName) : base(value, GetValidator(paramName))
    {
    }

    public static IValidator<int> GetValidator(string? paramName = null)
    {
        return new NonNegativeIntegerValidator(paramName ?? nameof(ValueIdentity));
    }
}