using StatAspect.Application.MediaTracking.Queries;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a search keys getting query validator.
/// <remarks>
/// <list type="bullet">
/// <item>Usable via reflection only.</item>
/// </list>
/// </remarks>
/// </summary>
public sealed class GetSearchKeysQueryValidator : AbstractValidator<GetSearchKeysQuery>
{
    /// <summary>
    /// Initializes a new instance of <see cref="GetSearchKeysQueryValidator"/>.
    /// <remarks>
    /// <list type="bullet">
    /// <item>Usable via reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    public GetSearchKeysQueryValidator()
    {
        RuleFor(q => q.Offset)
            .GreaterThanOrEqualTo(0);

        RuleFor(q => q.Limit)
            .GreaterThan(0);
    }
}