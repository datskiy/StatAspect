// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a <see cref="GetSearchKeyQuery"/> validator.
/// <remarks>Used only through reflection.</remarks>
/// </summary>
public sealed class GetSearchKeyQueryValidator : AbstractValidator<GetSearchKeyQuery>
{
    public GetSearchKeyQueryValidator()
    {
        RuleFor(q => q.Id)
            .SetValidator(SearchKeyId.GetValidator(nameof(GetSearchKeyQuery.Id)));
    }
}