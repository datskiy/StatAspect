using StatAspect.Domain._Common.ValueObjects.Abstractions;

namespace StatAspect.Domain._Core.UserRegistry.ValueObjects;

/// <summary>
/// Represents password salt.
/// </summary>
public sealed record PasswordSalt : ValueBase64
{
    /// <summary>
    /// Initializes a new instance of <see cref="PasswordSalt"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    public PasswordSalt(string value) : base(value, nameof(PasswordSalt))
    {
    }
}