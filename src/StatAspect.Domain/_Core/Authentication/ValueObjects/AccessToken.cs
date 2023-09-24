using StatAspect.Domain._Common.ValueObjects.Abstractions;
using StatAspect.Domain._Core.Authentication.Validators;

namespace StatAspect.Domain._Core.Authentication.ValueObjects;

/// <summary>
/// ***
/// </summary>
public record AccessToken : ValueObject<string>, IIntegrityObject<string>
{
    public AccessToken(string value) : base(value, GetValidator())
    {
    }

    public static IValidator<string> GetValidator(string? paramName = null)
    {
        return new AccessTokenValidator(paramName ?? nameof(AccessToken));
    }
}