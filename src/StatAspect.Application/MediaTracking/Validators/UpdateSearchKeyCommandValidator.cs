// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain._Common.Extensions;
using StatAspect.Domain.MediaTracking.ValueObjects;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents an <see cref="UpdateSearchKeyCommand"/> validator.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class UpdateSearchKeyCommandValidator : AbstractValidator<UpdateSearchKeyCommand>
{
    public UpdateSearchKeyCommandValidator()
    {
        RuleFor(c => c.Id)
            .AssignTo(SearchKeyId.GetValidator, nameof(UpdateSearchKeyCommand.Id));

        RuleFor(c => c.Name)
            .AssignTo(SearchKeyName.GetValidator, nameof(UpdateSearchKeyCommand.Name));

        RuleFor(c => c.Description)
            .AssignTo(SearchKeyDescription.GetValidator!, nameof(UpdateSearchKeyCommand.Description))
            .When(c => c.Description is not null);
    }
}