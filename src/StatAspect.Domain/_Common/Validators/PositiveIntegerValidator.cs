using StatAspect.Domain._Common.Extensions;

namespace StatAspect.Domain._Common.Validators;

/// <summary>
/// Represents a positive integer validator.
/// </summary>
public sealed class PositiveIntegerValidator : AbstractValidator<int>
{
    /// <summary>
    /// Initializes a new instance of <see cref="PositiveIntegerValidator"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public PositiveIntegerValidator(string paramName)
    {
        ArgumentNullException.ThrowIfNull(paramName);

        RuleFor(i => i)
            .GreaterThan(0)
            .UseCustomParamName(paramName);
    }
}