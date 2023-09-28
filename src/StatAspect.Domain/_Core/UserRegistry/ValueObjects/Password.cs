using StatAspect.Domain._Common.ValueObjects.Abstractions;
using StatAspect.Domain._Core.UserRegistry.Validators;

namespace StatAspect.Domain._Core.UserRegistry.ValueObjects;

/// <summary>
/// Represents a password.
/// </summary>
public sealed record Password : ValueObject<string>, IIntegrityEnsurer<string>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Password"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    public Password(string value) : base(value, GetValidator())
    {
    }

    public static IValidator<string> GetValidator(string? paramName = null)
    {
        return new PasswordValidator(paramName ?? nameof(Password));
    }
}