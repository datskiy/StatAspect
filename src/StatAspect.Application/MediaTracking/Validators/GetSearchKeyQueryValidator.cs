// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a search key getting query validator.
/// <remarks>Reflection only.</remarks>
/// </summary>
public sealed class GetSearchKeyQueryValidator : AbstractValidator<GetSearchKeyQuery>
{
    /// <summary>
    /// Initializes a new instance of <see cref="GetSearchKeyQueryValidator"/>.
    /// <remarks>Reflection only.</remarks>
    /// </summary>
    public GetSearchKeyQueryValidator()
    {
        RuleFor(q => q.Id)
            .SetValidator(SearchKeyId.GetValidator(nameof(GetSearchKeyQuery.Id)));
    }
}