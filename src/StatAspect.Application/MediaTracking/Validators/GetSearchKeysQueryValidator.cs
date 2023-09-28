// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain._Common.ValueObjects;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a <see cref="GetSearchKeysQuery"/> validator.
/// <remarks>Used only through reflection.</remarks>
/// </summary>
public sealed class GetSearchKeysQueryValidator : AbstractValidator<GetSearchKeysQuery>
{
    public GetSearchKeysQueryValidator()
    {
        RuleFor(q => q.Offset)
            .SetValidator(SelectionOffset.GetValidator(nameof(GetSearchKeysQuery.Offset)));

        RuleFor(q => q.Limit)
            .SetValidator(SelectionLimit.GetValidator(nameof(GetSearchKeysQuery.Limit)));
    }
}