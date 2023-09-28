using StatAspect.Domain._Common.Validators;

namespace StatAspect.Domain._Common.ValueObjects.Abstractions;

/// <summary>
/// Represents an abstract Base64 value object.
/// </summary>
public abstract record ValueBase64 : ValueObject<string>, IIntegrityEnsurer<string>
{
    /// <summary>
    /// Initializes a new instance of <see cref="ValueBase64"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    protected ValueBase64(string value, string paramName) : base(value, GetValidator(paramName))
    {
        ArgumentNullException.ThrowIfNull(paramName);
    }

    public static IValidator<string> GetValidator(string? paramName = null)
    {
        return new Base64Validator(paramName ?? nameof(ValueBase64));
    }
}