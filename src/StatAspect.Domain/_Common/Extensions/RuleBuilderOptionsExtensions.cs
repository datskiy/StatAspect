// ReSharper disable UnusedMethodReturnValue.Global

namespace StatAspect.Domain._Common.Extensions;

/// <summary>
/// Provides a set of extension methods for objects that implement <see cref="IRuleBuilderOptions{T, TProperty}"/>.
/// </summary>
public static class RuleBuilderOptionsExtensions
{
    /// <summary>
    /// TODO: desc
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static IRuleBuilderOptions<T, TProperty> UseCustomParamName<T, TProperty>(
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