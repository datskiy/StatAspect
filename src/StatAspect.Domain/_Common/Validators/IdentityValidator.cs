using StatAspect.Domain._Common.Extensions;

namespace StatAspect.Domain._Common.Validators;

/// <summary>
/// TODO: description
/// </summary>
public sealed class IdentityValidator : AbstractValidator<Guid>
{
    /// <summary>
    /// Initializes a new instance of <see cref="IdentityValidator"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public IdentityValidator(string paramName)
    {
        ArgumentNullException.ThrowIfNull(paramName);

        RuleFor(id => id)
            .NotEqual(default(Guid))
            .UseCustomParamName(paramName);
    }
}