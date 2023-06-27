// ReSharper disable UnusedMethodReturnValue.Global

namespace StatAspect.Application._Common.Extensions;

/// <summary>
/// Provides a set of extension methods for objects that implement <see cref="IRuleBuilder{T, TProperty}"/>.
/// </summary>
public static class RuleBuilderExtensions
{
    /// <summary>
    /// Defines an English alphabet validator on the current rule builder, but only for string properties.
    /// Validation will fail if any symbols of the string are outside of the range of the English alphabet.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static IRuleBuilderOptions<T, string> EnglishLettersOnly<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        Guard.Argument(() => ruleBuilder).NotNull();

        return ruleBuilder
            .Matches("^[a-zA-Z]+$")
            .WithMessage("{PropertyName} must only contain letters of the English alphabet.");
    }
}