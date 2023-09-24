// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain.MediaTracking.ValueObjects;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a search key update command validator.
/// <remarks>Reflection only.</remarks>
/// </summary>
public sealed class UpdateSearchKeyCommandValidator : AbstractValidator<UpdateSearchKeyCommand>
{
    /// <summary>
    /// Initializes a new instance of <see cref="UpdateSearchKeyCommandValidator"/>.
    /// <remarks>Reflection only.</remarks>
    /// </summary>
    public UpdateSearchKeyCommandValidator()
    {
        RuleFor(c => c.Id)
            .SetValidator(SearchKeyId.GetValidator(nameof(UpdateSearchKeyCommand.Id)));

        RuleFor(c => c.Name)
            .SetValidator(SearchKeyName.GetValidator(nameof(UpdateSearchKeyCommand.Name)));

        RuleFor(c => c.Description)
            .SetValidator(SearchKeyDescription.GetValidator(nameof(UpdateSearchKeyCommand.Description))!)
            .When(c => c.Description is not null);
    }
}