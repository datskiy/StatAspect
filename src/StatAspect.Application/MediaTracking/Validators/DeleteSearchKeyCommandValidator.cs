using StatAspect.Application.MediaTracking.Commands;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a search key deletion request validator.
/// </summary>
public sealed class DeleteSearchKeyCommandValidator : AbstractValidator<DeleteSearchKeyCommand>
{
    public DeleteSearchKeyCommandValidator()
    {
        RuleFor(c => c.Id)
            .GreaterThan(0);
    }
}