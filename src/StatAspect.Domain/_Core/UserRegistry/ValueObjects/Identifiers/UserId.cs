using StatAspect.Domain._Common.ValueObjects.Abstractions.Identifiers;

namespace StatAspect.Domain._Core.UserRegistry.ValueObjects.Identifiers;

/// <summary>
/// Represents a user unique identifier.
/// </summary>
public sealed record UserId : ObjectId
{
    /// <summary>
    /// Initializes a new instance of <see cref="UserId"/>.
    /// </summary>
    /// <exception cref="ArgumentException"/>
    public UserId(Guid value) : base(value)
    {
    }
}