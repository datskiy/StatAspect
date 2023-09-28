using StatAspect.Domain._Common.ValueObjects.Abstractions;

namespace StatAspect.Domain._Core.UserRegistry.ValueObjects;

/// <summary>
/// Represents password hash.
/// </summary>
public sealed record PasswordHash : ValueBase64
{
    /// <summary>
    /// Initializes a new instance of <see cref="PasswordHash"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    public PasswordHash(string value) : base(value, nameof(PasswordHash))
    {
    }
}