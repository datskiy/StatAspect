// ReSharper disable UnusedMethodReturnValue.Global

namespace StatAspect.Domain._Common.Extensions;

/// <summary>
/// Provides a set of extension methods for objects that implement <see cref="IRuleBuilder{T, TProperty}"/>.
/// </summary>
public static class RuleBuilderExtensions
{
    /// <summary>
    /// Defines an English alphabet validator on the target rule builder, but only for string properties.
    /// Validation will fail if any symbols of the string are outside of the range of the English alphabet.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static IRuleBuilderOptions<T, string> ContainsOnlyEnglishLetters<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        ArgumentNullException.ThrowIfNull(ruleBuilder);

        return ruleBuilder
            .Matches("^[a-zA-Z]+$")
            .WithMessage("{PropertyName} must only contain letters of the English alphabet.");
    }

    /// <summary>
    /// TODO: desc
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static IRuleBuilderOptions<T, string> FormattedAsBase64<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        ArgumentNullException.ThrowIfNull(ruleBuilder);

        return ruleBuilder
            .Must(str => Convert.TryFromBase64String(str, new Span<byte>(new byte[str.Length]), out _));
    }

    /// <summary>
    /// TODO: desc
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static IRuleBuilderOptions<T, string> FormattedAsJwt<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        ArgumentNullException.ThrowIfNull(ruleBuilder);

        return ruleBuilder
            .Must(str => new JwtSecurityTokenHandler().CanReadToken(str));
    }
}