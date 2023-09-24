// ReSharper disable UnusedType.Global

using StatAspect.Application._Core.Authentication.Queries;
using StatAspect.Domain._Core.UserRegistry.ValueObjects;

namespace StatAspect.Application._Core.Authentication.Validators;

/// <summary>
/// Represents an access permission getting query validator.
/// <remarks>Reflection only.</remarks>
/// </summary>
public sealed class GetAccessPermissionQueryValidator : AbstractValidator<GetAccessPermissionQuery>
{
    /// <summary>
    /// Initializes a new instance of <see cref="GetAccessPermissionQueryValidator"/>.
    /// <remarks>Reflection only.</remarks>
    /// </summary>
    public GetAccessPermissionQueryValidator()
    {
        RuleFor(q => q.Username)
            .SetValidator(Username.GetValidator(nameof(GetAccessPermissionQuery.Username)));

        RuleFor(q => q.Password)
            .SetValidator(Password.GetValidator(nameof(GetAccessPermissionQuery.Password)));
    }
}