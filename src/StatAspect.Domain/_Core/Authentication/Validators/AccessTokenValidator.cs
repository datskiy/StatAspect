using StatAspect.Domain._Common.Extensions;

namespace StatAspect.Domain._Core.Authentication.Validators;

/// <summary>
/// Represents an access token validator.
/// </summary>
public sealed class AccessTokenValidator : AbstractValidator<string>
{
    /// <summary>
    /// Initializes a new instance of <see cref="AccessTokenValidator"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public AccessTokenValidator(string paramName)
    {
        ArgumentNullException.ThrowIfNull(paramName);

        RuleFor(password => password)
            .NotNull()
            .NotEmpty()
            .FormattedAsJwt()
            .UseCustomParamName(paramName);
    }
}