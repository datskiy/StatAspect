using StatAspect.Application.MediaTracking.Queries;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a search keys read request validator.
/// </summary>
public sealed class GetSearchKeysQueryValidator : AbstractValidator<GetSearchKeysQuery>
{
    public GetSearchKeysQueryValidator()
    {
        RuleFor(q => q.Offset)
            .GreaterThanOrEqualTo(0);

        RuleFor(q => q.Limit)
            .GreaterThan(0);
    }
}