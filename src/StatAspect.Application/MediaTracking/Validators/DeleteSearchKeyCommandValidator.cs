using StatAspect.Application.MediaTracking.Commands;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a search key deletion command validator.
/// <remarks>
/// <list type="bullet">
/// <item>Usable via reflection only.</item>
/// </list>
/// </remarks>
/// </summary>
public sealed class DeleteSearchKeyCommandValidator : AbstractValidator<DeleteSearchKeyCommand>
{
    /// <summary>
    /// Initializes a new instance of <see cref="DeleteSearchKeyCommandValidator"/>.
    /// <remarks>
    /// <list type="bullet">
    /// <item>Usable via reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    public DeleteSearchKeyCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();
    }
}