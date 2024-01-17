using StatAspect.Domain._Common.Extensions;

namespace StatAspect.Domain._Common.Validators;

/// <summary>
/// Represents a non-negative integer validator.
/// </summary>
public sealed class NonNegativeIntegerValidator : AbstractValidator<int>
{
    /// <summary>
    /// Initializes a new instance of <see cref="NonNegativeIntegerValidator"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public NonNegativeIntegerValidator(string paramName)
    {
        ArgumentNullException.ThrowIfNull(paramName);

        RuleFor(i => i)
            .GreaterThanOrEqualTo(0)
            .OverrideAssociatedPropertyName(paramName);
    }
}