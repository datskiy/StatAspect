// ReSharper disable UnusedMethodReturnValue.Global

namespace StatAspect.Domain._Common.Extensions;

/// <summary>
/// Provides a set of extension methods for types that implement <see cref="IRuleBuilder{T, TProperty}"/>.
/// </summary>
public static class RuleBuilderExtensions
{
    /// <summary>
    /// Defines an English character validator on the target rule builder, but only for string properties.
    /// Validation will fail if the string contains any non-English characters.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static IRuleBuilderOptions<T, string> ContainsOnlyEnglishCharacters<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        ArgumentNullException.ThrowIfNull(ruleBuilder);

        return ruleBuilder
            .Matches("^[a-zA-Z]+$")
            .WithMessage("{PropertyName} must only contain letters of the English alphabet.");
    }

    /// <summary>
    /// Defines a Base64 format validator on the target rule builder, but only for string properties.
    /// Validation will fail if the string is not formatted as Base64.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static IRuleBuilderOptions<T, string> FormattedAsBase64<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        ArgumentNullException.ThrowIfNull(ruleBuilder);

        return ruleBuilder
            .Must(str => Convert.TryFromBase64String(str, new Span<byte>(new byte[str.Length]), out _));
    }

    /// <summary>
    /// Defines a JWT format validator on the target rule builder, but only for string properties.
    /// Validation will fail if the string is not formatted as JWT.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static IRuleBuilderOptions<T, string> FormattedAsJwt<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        ArgumentNullException.ThrowIfNull(ruleBuilder);

        return ruleBuilder
            .Must(str => new JwtSecurityTokenHandler().CanReadToken(str));
    }
}