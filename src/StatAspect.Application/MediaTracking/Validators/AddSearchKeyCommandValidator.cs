// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain.MediaTracking.Metas;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a new search key addition command validator.
/// <remarks>
/// <list type="bullet">
/// <item>Reflection only.</item>
/// </list>
/// </remarks>
/// </summary>
public sealed class AddSearchKeyCommandValidator : AbstractValidator<AddSearchKeyCommand>
{
    /// <summary>
    /// Initializes a new instance of <see cref="AddSearchKeyCommandValidator"/>.
    /// <remarks>
    /// <list type="bullet">
    /// <item>Reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    public AddSearchKeyCommandValidator()
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