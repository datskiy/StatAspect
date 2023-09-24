using StatAspect.Domain._Common.ValueObjects.Abstractions;
using StatAspect.Domain._Core.UserRegistry.Validators;

namespace StatAspect.Domain._Core.UserRegistry.ValueObjects;

/// <summary>
/// ***
/// </summary>
public record Username : ValueObject<string>, IIntegrityObject<string>
{
    public Username(string value) : base(value, GetValidator())
    {
    }

    public static IValidator<string> GetValidator(string? paramName = null)
    {
        return new UsernameValidator(paramName ?? nameof(Username));
    }
}