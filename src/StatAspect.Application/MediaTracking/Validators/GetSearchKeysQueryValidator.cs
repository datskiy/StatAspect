// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain._Common.ValueObjects;

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
        RuleFor(q => q.Offset)
            .SetValidator(SelectionOffset.GetValidator(nameof(GetSearchKeysQuery.Offset)));

        RuleFor(q => q.Limit)
            .SetValidator(SelectionLimit.GetValidator(nameof(GetSearchKeysQuery.Limit)));
    }
}