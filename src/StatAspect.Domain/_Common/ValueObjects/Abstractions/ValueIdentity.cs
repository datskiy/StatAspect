using StatAspect.Domain._Common.Validators;

namespace StatAspect.Domain._Common.ValueObjects.Abstractions;

/// <summary>
/// Represents a unique identifier. // TODO: desc
/// </summary>
public abstract record ValueIdentity : ValueObject<Guid>, IIntegrityObject<Guid>
{
    /// <summary>
    /// Initializes a new instance of <see cref="ValueIdentity"/>.
    /// </summary>
    /// <exception cref="ArgumentException"/>
    protected ValueIdentity(Guid value, string paramName) : base(value, GetValidator(paramName))
    {
    }

    public static IValidator<Guid> GetValidator(string? paramName = null)
    {
        return new IdentityValidator(paramName ?? nameof(ValueIdentity));
    }
}