using StatAspect.Domain._Common.ValueObjects.Abstractions;
using StatAspect.Domain._Core.UserRegistry.Validators;

namespace StatAspect.Domain._Core.UserRegistry.ValueObjects;

/// <summary>
/// Represents a username.
/// </summary>
public sealed record Username : ValueObject<string>, IIntegrityEnsurer<string>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Username"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    public Username(string value) : base(value, GetValidator())
    {
    }

    public static IValidator<string> GetValidator(string? paramName = null)
    {
        return new UsernameValidator(paramName ?? nameof(Username));
    }
}