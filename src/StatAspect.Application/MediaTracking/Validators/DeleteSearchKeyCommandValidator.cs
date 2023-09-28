// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a <see cref="DeleteSearchKeyCommand"/> validator.
/// <remarks>Used only through reflection.</remarks>
/// </summary>
public sealed class DeleteSearchKeyCommandValidator : AbstractValidator<DeleteSearchKeyCommand>
{
    public DeleteSearchKeyCommandValidator()
    {
        RuleFor(c => c.Id)
            .SetValidator(SearchKeyId.GetValidator(nameof(DeleteSearchKeyCommand.Id)));
    }
}