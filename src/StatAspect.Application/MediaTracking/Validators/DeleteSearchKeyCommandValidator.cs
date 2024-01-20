// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain._Common.Extensions;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a <see cref="DeleteSearchKeyCommand"/> validator.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class DeleteSearchKeyCommandValidator : AbstractValidator<DeleteSearchKeyCommand>
{
    public DeleteSearchKeyCommandValidator()
    {
        RuleFor(c => c.Id)
            .AssignTo(SearchKeyId.GetValidator, nameof(DeleteSearchKeyCommand.Id));
    }
}