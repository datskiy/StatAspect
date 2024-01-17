using StatAspect.Domain._Common.Extensions;
using StatAspect.Domain._Core.UserRegistry.Specifications;

namespace StatAspect.Domain._Core.UserRegistry.Validators;

/// <summary>
/// Represents a username validator.
/// </summary>
public sealed class UsernameValidator : AbstractValidator<string>
{
    /// <summary>
    /// Initializes a new instance of <see cref="UsernameValidator"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public UsernameValidator(string paramName)
    {
        ArgumentNullException.ThrowIfNull(paramName);

        RuleFor(username => username)
            .NotNull()
            .NotEmpty()
            .MaximumLength(UserCredentialsSpecification.UsernameMaxLength)
            .ContainsOnlyEnglishCharacters()
            .OverrideAssociatedPropertyName(paramName);
    }
}