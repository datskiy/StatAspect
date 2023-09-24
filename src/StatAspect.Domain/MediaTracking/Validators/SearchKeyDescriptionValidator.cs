using StatAspect.Domain._Common.Extensions;
using StatAspect.Domain.MediaTracking.Specifications;

namespace StatAspect.Domain.MediaTracking.Validators;

/// <summary>
/// TODO: description
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
            .MaximumLength(SearchKeySpecification.MaxDescriptionLength)
            .When(description => description is not null)
            .UseCustomParamName(paramName);
    }
}