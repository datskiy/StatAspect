// ReSharper disable UnusedType.Global

using StatAspect.Application._Common.Extensions;
using StatAspect.Application._Core.Authentication.Queries;

namespace StatAspect.Application._Core.Authentication.Validators;

/// <summary>
/// Represents an access token getting query validator.
/// <remarks>
/// <list type="bullet">
/// <item>Reflection only.</item>
/// </list>
/// </remarks>
/// </summary>
public sealed class GetAccessTokenQueryValidator : AbstractValidator<GetAccessTokenQuery>
{
    /// <summary>
    /// Initializes a new instance of <see cref="GetAccessTokenQueryValidator"/>.
    /// <remarks>
    /// <list type="bullet">
    /// <item>Reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    public GetAccessTokenQueryValidator()
    {
        RuleFor(q => q.Username)
            .NotNull()
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(50)
            .EnglishLettersOnly();

        RuleFor(c => c.Password)
            .NotNull()
            .NotEmpty()
            .MinimumLength(10);
    }
}