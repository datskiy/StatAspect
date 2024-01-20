// ReSharper disable UnusedType.Global

using StatAspect.Application._Core.Authentication.Commands;
using StatAspect.Domain._Common.Extensions;
using StatAspect.Domain._Core.UserRegistry.ValueObjects;

namespace StatAspect.Application._Core.Authentication.Validators;

/// <summary>
/// Represents a <see cref="IssueAccessPermissionCommand"/> validator.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class IssueAccessPermissionCommandValidator : AbstractValidator<IssueAccessPermissionCommand>
{
    public IssueAccessPermissionCommandValidator()
    {
        RuleFor(q => q.Username)
            .AssignTo(Username.GetValidator, nameof(IssueAccessPermissionCommand.Username));

        RuleFor(q => q.Password)
            .AssignTo(Password.GetValidator, nameof(IssueAccessPermissionCommand.Password));
    }
}