using StatAspect.Domain._Common.Validators;

namespace StatAspect.Domain._Common.ValueObjects.Abstractions;

/// <summary>
/// Represents a unique identifier. // TODO: desc
/// </summary>
public abstract record ValueBase64String : ValueObject<string>, IIntegrityObject<string>
{
    /// <summary>
    /// Initializes a new instance of <see cref="ValueBase64String"/>.
    /// </summary>
    /// <exception cref="ArgumentException"/>
    protected ValueBase64String(string value, string paramName) : base(value, GetValidator(paramName))
    {
    }

    public static IValidator<string> GetValidator(string? paramName = null)
    {
        return new Base64StringValidator(paramName ?? nameof(ValueBase64String));
    }
}