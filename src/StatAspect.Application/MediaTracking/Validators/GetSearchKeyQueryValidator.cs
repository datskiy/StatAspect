using StatAspect.Application.MediaTracking.Queries;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a search key read request validator.
/// </summary>
public sealed class GetSearchKeyQueryValidator : AbstractValidator<GetSearchKeyQuery>
{
    public GetSearchKeyQueryValidator()
    {
        RuleFor(q => q.Id)
            .GreaterThan(0);
    }
}