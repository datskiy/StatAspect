using StatAspect.Domain._Common.Validators;

namespace StatAspect.Domain._Common.ValueObjects.Abstractions;

/// <summary>
/// TODO: description
/// </summary>
public abstract record ValuePositiveInteger : ValueObject<int>, IIntegrityObject<int>
{
    /// <summary>
    /// Initializes a new instance of <see cref="ValuePositiveInteger"/>.
    /// </summary>
    /// <exception cref="ArgumentException"/>
    protected ValuePositiveInteger(int value, string paramName) : base(value, GetValidator(paramName))
    {
    }

    public static IValidator<int> GetValidator(string? paramName = null)
    {
        return new PositiveIntegerValidator(paramName ?? nameof(ValueIdentity));
    }
}