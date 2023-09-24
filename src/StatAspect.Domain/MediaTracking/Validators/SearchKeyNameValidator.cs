using StatAspect.Domain._Common.Extensions;
using StatAspect.Domain.MediaTracking.Specifications;

namespace StatAspect.Domain.MediaTracking.Validators;

/// <summary>
/// TODO: description
/// </summary>
public sealed class SearchKeyNameValidator : AbstractValidator<string>
{
    /// <summary>
    /// Initializes a new instance of <see cref="SearchKeyNameValidator"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public SearchKeyNameValidator(string paramName)
    {
        ArgumentNullException.ThrowIfNull(paramName);

        RuleFor(name => name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(SearchKeySpecification.MaxNameLength)
            .UseCustomParamName(paramName);
    }
}