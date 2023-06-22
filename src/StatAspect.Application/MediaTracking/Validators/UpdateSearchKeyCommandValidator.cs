// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain.MediaTracking.Metas;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a search key update command validator.
/// <remarks>
/// <list type="bullet">
/// <item>Reflection only.</item>
/// </list>
/// </remarks>
/// </summary>
public sealed class UpdateSearchKeyCommandValidator : AbstractValidator<UpdateSearchKeyCommand>
{
    /// <summary>
    /// Initializes a new instance of <see cref="UpdateSearchKeyCommandValidator"/>.
    /// <remarks>
    /// <list type="bullet">
    /// <item>Reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    public UpdateSearchKeyCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(SearchKeyMeta.MaxNameLength);

        RuleFor(c => c.Description)
            .NotEmpty()
            .MaximumLength(SearchKeyMeta.MaxDescriptionLength)
            .When(c => c.Description is not null);
    }
}