// ReSharper disable UnusedType.Global
// ReSharper disable UnusedParameter.Local

using StatAspect.Application._Core.Authentication.Commands;
using StatAspect.Application._Core.Authentication.Options;
using StatAspect.Domain._Core.Authentication.Aggregates;
using StatAspect.Domain._Core.Authentication.Managers;
using StatAspect.Domain._Core.UserRegistry.Managers;
using StatAspect.Domain._Core.UserRegistry.ValueObjects;
using StatAspect.SharedKernel.OneOf.Results;

namespace StatAspect.Application._Core.Authentication.Handlers;

/// <summary>
/// Represents a <see cref="IssueAccessPermissionCommand"/> handler.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class ClaimAccessPermissionHandler : IRequestHandler<IssueAccessPermissionCommand, OneOf<AccessPermission, AccessDenied>>
{
    private readonly IAccessPermissionManager _accessPermissionManager;
    private readonly IOptions<AuthenticationPolicies> _authenticationPolicies;
    private readonly IUserCredentialsManager _userCredentialsManager;

    private static Task<OneOf<AccessPermission, AccessDenied>> AccessDeniedResult =>
        Task.FromResult<OneOf<AccessPermission, AccessDenied>>(new AccessDenied());

    public ClaimAccessPermissionHandler(
        IAccessPermissionManager accessPermissionManager,
        IOptions<AuthenticationPolicies> authenticationPolicies,
        IUserCredentialsManager userCredentialsManager)
    {
        _accessPermissionManager = accessPermissionManager;
        _authenticationPolicies = authenticationPolicies;
        _userCredentialsManager = userCredentialsManager;
    }

    /// <summary>
    /// Handles the <see cref="IssueAccessPermissionCommand"/>.
    /// <remarks>Reflection usage only.</remarks>
    /// </summary>
    public async Task<OneOf<AccessPermission, AccessDenied>> Handle(IssueAccessPermissionCommand command, CancellationToken cancellationToken)
    {
        var verificationResult = await _userCredentialsManager.VerifyAsync(
            new Username(command.Username),
            new Password(command.Password),
            cancellationToken);

        var accessPermissionLifetime = _authenticationPolicies.Value.AccessPermissionLifetime;
        return await verificationResult.Match<Task<OneOf<AccessPermission, AccessDenied>>>(
            async matchedUserId => await _accessPermissionManager.GrantAsync(matchedUserId, accessPermissionLifetime),
            notFound => AccessDeniedResult,
            mismatched => AccessDeniedResult);
    }
}