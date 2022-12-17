using StatAspect.Application.MediaTracking.Commands;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a new search key addition command validator.
/// <remarks>
/// <list type="bullet">
/// <item>Usable via reflection only.</item>
/// </list>
/// </remarks>
/// </summary>
public sealed class AddSearchKeyCommandValidator : AbstractValidator<AddSearchKeyCommand>
{
    private const int MaxNameLength = 20;
    private const int MaxDescriptionLength = 50;

    /// <summary>
    /// Initializes a new instance of <see cref="AddSearchKeyCommandValidator"/>.
    /// <remarks>
    /// <list type="bullet">
    /// <item>Usable via reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    public AddSearchKeyCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(MaxNameLength);

        RuleFor(c => c.Description)
            .NotEmpty()
            .MaximumLength(MaxDescriptionLength)
            .When(c => c.Description is not null);
    }
}