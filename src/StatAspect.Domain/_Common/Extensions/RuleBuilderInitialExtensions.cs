namespace StatAspect.Domain._Common.Extensions;

/// <summary>
/// Provides a set of extension methods for types that implement <see cref="IRuleBuilderInitial{T, TProperty}"/>.
/// </summary>
public static class RuleBuilderInitialExtensions
{
    /// <summary>
    /// Assigns the specified validator to the rule builder.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static IRuleBuilderOptions<T, TProperty> AssignTo<T, TProperty>(
        this IRuleBuilderInitial<T, TProperty> initialRuleBuilder,
        Func<string, IValidator<TProperty>> getValidator,
        string paramName)
    {
        ArgumentNullException.ThrowIfNull(initialRuleBuilder);
        ArgumentNullException.ThrowIfNull(getValidator);
        ArgumentNullException.ThrowIfNull(paramName);

        return initialRuleBuilder
            .NotNull()
            .OverrideAssociatedPropertyName(paramName)
            .SetValidator(getValidator(paramName));
    }
}