// ReSharper disable UnusedType.Global

using StatAspect.Application._Core.Authentication.Commands;
using StatAspect.Domain._Core.UserRegistry.ValueObjects;

namespace StatAspect.Application._Core.Authentication.Validators;

/// <summary>
/// Represents a <see cref="IssueAccessPermissionCommand"/> validator.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class GetAccessPermissionQueryValidator : AbstractValidator<IssueAccessPermissionCommand>
{
    public GetAccessPermissionQueryValidator()
    {
        RuleFor(q => q.Username)
            .SetValidator(Username.GetValidator(nameof(IssueAccessPermissionCommand.Username)));

        RuleFor(q => q.Password)
            .SetValidator(Password.GetValidator(nameof(IssueAccessPermissionCommand.Password)));
    }
}