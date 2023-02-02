using StatAspect.Application.MediaTracking.Queries;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a search key getting query validator.
/// <remarks>
/// <list type="bullet">
/// <item>Usable via reflection only.</item>
/// </list>
/// </remarks>
/// </summary>
public sealed class GetSearchKeyQueryValidator : AbstractValidator<GetSearchKeyQuery>
{
    /// <summary>
    /// Initializes a new instance of <see cref="GetSearchKeyQueryValidator"/>.
    /// <remarks>
    /// <list type="bullet">
    /// <item>Usable via reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    public GetSearchKeyQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}