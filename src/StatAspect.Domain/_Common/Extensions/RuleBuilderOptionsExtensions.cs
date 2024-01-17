namespace StatAspect.Domain._Common.Extensions;

/// <summary>
/// Provides a set of extension methods for types that implement <see cref="IRuleBuilderOptions{T, TProperty}"/>.
/// </summary>
public static class RuleBuilderOptionsExtensions
{
    /// <summary>
    /// Overrides associated with a rule property name with the specified parameter name.
    /// Also overrides the name of the property used within an error message.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static IRuleBuilderOptions<T, TProperty> OverrideAssociatedPropertyName<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> ruleBuilderOptions,
        string paramName)
    {
        ArgumentNullException.ThrowIfNull(ruleBuilderOptions);
        ArgumentNullException.ThrowIfNull(paramName);

        return ruleBuilderOptions
            .WithName(paramName)
            .OverridePropertyName(string.Empty);
    }
}