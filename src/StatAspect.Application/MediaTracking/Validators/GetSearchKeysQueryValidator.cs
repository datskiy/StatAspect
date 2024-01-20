// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain._Common.Extensions;
using StatAspect.Domain._Common.ValueObjects;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a <see cref="GetSearchKeysQuery"/> validator.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class GetSearchKeysQueryValidator : AbstractValidator<GetSearchKeysQuery>
{
    public GetSearchKeysQueryValidator()
    {
        RuleFor(q => q.Offset)
            .AssignTo(SelectionOffset.GetValidator, nameof(GetSearchKeysQuery.Offset));

        RuleFor(q => q.Limit)
            .AssignTo(SelectionLimit.GetValidator, nameof(GetSearchKeysQuery.Limit));
    }
}