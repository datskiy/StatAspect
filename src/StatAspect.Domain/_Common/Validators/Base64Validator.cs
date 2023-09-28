using StatAspect.Domain._Common.Extensions;

namespace StatAspect.Domain._Common.Validators;

/// <summary>
/// Represents a Base64 format validator.
/// </summary>
public sealed class Base64Validator : AbstractValidator<string>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Base64Validator"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Base64Validator(string paramName)
    {
        ArgumentNullException.ThrowIfNull(paramName);

        RuleFor(base64 => base64)
            .NotNull()
            .NotEmpty()
            .FormattedAsBase64()
            .UseCustomParamName(paramName);
    }
}