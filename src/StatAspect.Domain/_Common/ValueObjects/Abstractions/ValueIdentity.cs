using StatAspect.Domain._Common.Validators;

namespace StatAspect.Domain._Common.ValueObjects.Abstractions;

/// <summary>
/// Represents an abstract <see cref="Guid"/>-based identity value object.
/// </summary>
public abstract record ValueIdentity : ValueObject<Guid>, IIntegrityEnsurer<Guid>
{
    /// <summary>
    /// Initializes a new instance of <see cref="ValueIdentity"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    protected ValueIdentity(Guid value, string paramName) : base(value, GetValidator(paramName))
    {
        ArgumentNullException.ThrowIfNull(paramName);
    }

    public static IValidator<Guid> GetValidator(string? paramName = null)
    {
        return new IdentityValidator(paramName ?? nameof(ValueIdentity));
    }
}