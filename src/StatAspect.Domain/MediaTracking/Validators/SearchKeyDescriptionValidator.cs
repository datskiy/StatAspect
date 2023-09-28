using StatAspect.Domain._Common.Extensions;
using StatAspect.Domain.MediaTracking.Specifications;

namespace StatAspect.Domain.MediaTracking.Validators;

/// <summary>
/// Represents a search key description validator.
/// </summary>
public sealed class SearchKeyDescriptionValidator : AbstractValidator<string>
{
    /// <summary>
    /// Initializes a new instance of <see cref="SearchKeyDescriptionValidator"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public SearchKeyDescriptionValidator(string paramName)
    {
        ArgumentNullException.ThrowIfNull(paramName);

        RuleFor(description => description)
            .NotEmpty()
            .MaximumLength(SearchKeySpecification.DescriptionMaxLength)
            .UseCustomParamName(paramName)
            .When(description => description is not null);
    }
}