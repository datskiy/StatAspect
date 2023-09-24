using StatAspect.Domain._Common.Extensions;
using StatAspect.Domain._Core.UserRegistry.Specifications;

namespace StatAspect.Domain._Core.UserRegistry.Validators;

/// <summary>
/// TODO: description
/// </summary>
public sealed class PasswordValidator : AbstractValidator<string>
{
    /// <summary>
    /// Initializes a new instance of <see cref="PasswordValidator"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public PasswordValidator(string paramName)
    {
        ArgumentNullException.ThrowIfNull(paramName);

        RuleFor(password => password)
            .NotNull()
            .NotEmpty()
            .MinimumLength(UserCredentialsSpecification.MinPasswordLength)
            .UseCustomParamName(paramName);
    }
}