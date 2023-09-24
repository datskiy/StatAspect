using StatAspect.Domain._Common.ValueObjects.Abstractions;
using StatAspect.Domain._Core.UserRegistry.Validators;

namespace StatAspect.Domain._Core.UserRegistry.ValueObjects;

/// <summary>
/// ***
/// </summary>
public record Password : ValueObject<string>, IIntegrityObject<string>
{
    public Password(string value) : base(value, GetValidator())
    {
    }

    public static IValidator<string> GetValidator(string? paramName = null)
    {
        return new PasswordValidator(paramName ?? nameof(Password));
    }
}