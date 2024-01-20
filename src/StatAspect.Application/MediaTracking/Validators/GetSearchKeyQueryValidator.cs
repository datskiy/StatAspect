// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain._Common.Extensions;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a <see cref="GetSearchKeyQuery"/> validator.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class GetSearchKeyQueryValidator : AbstractValidator<GetSearchKeyQuery>
{
    public GetSearchKeyQueryValidator()
    {
        RuleFor(q => q.Id)
            .AssignTo(SearchKeyId.GetValidator, nameof(GetSearchKeyQuery.Id));
    }
}