// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Queries;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a search keys getting query validator.
/// <remarks>Reflection only.</remarks>
/// </summary>
public sealed class GetSearchKeysQueryValidator : AbstractValidator<GetSearchKeysQuery>
{
    /// <summary>
    /// Initializes a new instance of <see cref="GetSearchKeysQueryValidator"/>.
    /// <remarks>Reflection only.</remarks>
    /// </summary>
    public GetSearchKeysQueryValidator()
    {
        RuleFor(q => q.Offset) // TODO: fix
            .GreaterThanOrEqualTo(0);

        RuleFor(q => q.Limit)
            .GreaterThan(0);
    }
}