using StatAspect.Domain._Common.ValueObjects.Abstractions;
using StatAspect.Domain._Core.Authentication.Validators;

namespace StatAspect.Domain._Core.Authentication.ValueObjects;

/// <summary>
/// Represents an access token.
/// </summary>
public sealed record AccessToken : ValueObject<string>, IIntegrityEnsurer<string>
{
    /// <summary>
    /// Initializes a new instance of <see cref="AccessToken"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public AccessToken(string value) : base(value, GetValidator())
    {
    }

    public static IValidator<string> GetValidator(string? paramName = null)
    {
        return new AccessTokenValidator(paramName ?? nameof(AccessToken));
    }
}