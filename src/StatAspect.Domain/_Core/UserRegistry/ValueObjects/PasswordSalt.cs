using StatAspect.Domain._Common.ValueObjects.Abstractions;
using StatAspect.Domain._Core.UserRegistry.Validators;

namespace StatAspect.Domain._Core.UserRegistry.ValueObjects;

/// <summary>
/// ***
/// </summary>
public record PasswordSalt : ValueBase64String
{
    public PasswordSalt(string value) : base(value, nameof(PasswordSalt))
    {
    }
}