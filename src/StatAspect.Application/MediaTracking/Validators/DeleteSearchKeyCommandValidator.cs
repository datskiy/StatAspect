// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a search key deletion command validator.
/// <remarks>Reflection only.</remarks>
/// </summary>
public sealed class DeleteSearchKeyCommandValidator : AbstractValidator<DeleteSearchKeyCommand>
{
    /// <summary>
    /// Initializes a new instance of <see cref="DeleteSearchKeyCommandValidator"/>.
    /// <remarks>Reflection only.</remarks>
    /// </summary>
    public DeleteSearchKeyCommandValidator()
    {
        RuleFor(c => c.Id)
            .SetValidator(SearchKeyId.GetValidator(nameof(DeleteSearchKeyCommand.Id)));
    }
}