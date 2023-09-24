// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain.MediaTracking.ValueObjects;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a search key addition command validator.
/// <remarks>Reflection only.</remarks>
/// </summary>
public sealed class AddSearchKeyCommandValidator : AbstractValidator<AddSearchKeyCommand>
{
    /// <summary>
    /// Initializes a new instance of <see cref="AddSearchKeyCommandValidator"/>.
    /// <remarks>Reflection only.</remarks>
    /// </summary>
    public AddSearchKeyCommandValidator()
    {
        RuleFor(c => c.Name)
            .SetValidator(SearchKeyName.GetValidator(nameof(AddSearchKeyCommand.Name)));

        RuleFor(c => c.Description)
            .SetValidator(SearchKeyDescription.GetValidator(nameof(AddSearchKeyCommand.Description))!)
            .When(c => c.Description is not null);
    }
}