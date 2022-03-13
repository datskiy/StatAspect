﻿using StatAspect.Application.MediaTracking.Commands;

namespace StatAspect.Application.MediaTracking.Validators;

/// <summary>
/// Represents a search key update request validator.
/// </summary>
public sealed class UpdateSearchKeyCommandValidator : AbstractValidator<UpdateSearchKeyCommand>
{
    private const int MaxNameLength = 20;
    private const int MaxDescriptionLength = 50;

    public UpdateSearchKeyCommandValidator()
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