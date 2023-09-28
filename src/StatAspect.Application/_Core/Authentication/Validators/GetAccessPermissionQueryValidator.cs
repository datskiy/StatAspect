// ReSharper disable UnusedType.Global

using StatAspect.Application._Core.Authentication.Queries;
using StatAspect.Domain._Core.UserRegistry.ValueObjects;

namespace StatAspect.Application._Core.Authentication.Validators;

/// <summary>
/// Represents a <see cref="GetAccessPermissionQuery"/> validator.
/// <remarks>Used only through reflection.</remarks>
/// </summary>
public sealed class GetAccessPermissionQueryValidator : AbstractValidator<GetAccessPermissionQuery>
{
    public GetAccessPermissionQueryValidator()
    {
        RuleFor(q => q.Username)
            .SetValidator(Username.GetValidator(nameof(GetAccessPermissionQuery.Username)));

        RuleFor(q => q.Password)
            .SetValidator(Password.GetValidator(nameof(GetAccessPermissionQuery.Password)));
    }
}