// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain._Common.Extensions;
using StatAspect.Domain.MediaTracking.ValueObjects;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents an <see cref="AddSearchKeyCommand"/> validator.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class AddSearchKeyCommandValidator : AbstractValidator<AddSearchKeyCommand>
{
    public AddSearchKeyCommandValidator()
    {
        RuleFor(c => c.Name)
            .AssignTo(SearchKeyName.GetValidator, nameof(AddSearchKeyCommand.Name));

        RuleFor(c => c.Description)
            .AssignTo(SearchKeyDescription.GetValidator!, nameof(AddSearchKeyCommand.Description))
            .When(c => c.Description is not null);
    }
}