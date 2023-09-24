using StatAspect.Domain._Common.Extensions;

namespace StatAspect.Domain._Common.Validators;

/// <summary>
/// TODO: description
/// </summary>
public sealed class Base64StringValidator : AbstractValidator<string>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Base64StringValidator"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Base64StringValidator(string paramName)
    {
        ArgumentNullException.ThrowIfNull(paramName);

        RuleFor(base64 => base64)
            .NotNull()
            .NotEmpty()
            .FormattedAsBase64()
            .UseCustomParamName(paramName);
    }
}