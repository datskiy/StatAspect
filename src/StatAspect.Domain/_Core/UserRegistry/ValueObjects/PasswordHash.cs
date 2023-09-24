using StatAspect.Domain._Common.ValueObjects.Abstractions;
using StatAspect.Domain._Core.UserRegistry.Validators;

namespace StatAspect.Domain._Core.UserRegistry.ValueObjects;

/// <summary>
/// ***
/// </summary>
public record PasswordHash : ValueBase64String
{
    public PasswordHash(string value) : base(value, nameof(PasswordHash))
    {
    }
}