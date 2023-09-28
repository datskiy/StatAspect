// ReSharper disable UnusedType.Global
// ReSharper disable UnusedParameter.Local

using StatAspect.Application._Core.Authentication.Queries;
using StatAspect.Domain._Core.Authentication.Aggregates;
using StatAspect.Domain._Core.Authentication.Managers;
using StatAspect.Domain._Core.UserRegistry.Managers;
using StatAspect.Domain._Core.UserRegistry.ValueObjects;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Application._Core.Authentication.Handlers;

/// <summary>
/// Represents an <see cref="GetAccessPermissionQuery"/> handler.
/// <remarks>Used only through reflection.</remarks>
/// </summary>
public sealed class GetAccessPermissionHandler : IRequestHandler<GetAccessPermissionQuery, OneOf<AccessPermission, AccessDenied>>
{
    private readonly IAccessPermissionManager _accessPermissionManager;
    private readonly IUserCredentialsManager _userCredentialsManager;

    private static Task<OneOf<AccessPermission, AccessDenied>> AccessDeniedResult => Task.FromResult<OneOf<AccessPermission, AccessDenied>>(new AccessDenied());

    public GetAccessPermissionHandler(
        IAccessPermissionManager accessPermissionManager,
        IUserCredentialsManager userCredentialsManager)
    {
        _accessPermissionManager = accessPermissionManager;
        _userCredentialsManager = userCredentialsManager;
    }

    /// <summary>
    /// Handles the <see cref="GetAccessPermissionQuery"/> request.
    /// <remarks>Used only through reflection.</remarks>
    /// </summary>
    public async Task<OneOf<AccessPermission, AccessDenied>> Handle(GetAccessPermissionQuery query, CancellationToken cancellationToken)
    {
        var verificationResult = await _userCredentialsManager.VerifyAsync(
            new Username(query.Username),
            new Password(query.Password),
            cancellationToken);

        return await verificationResult.Match<Task<OneOf<AccessPermission, AccessDenied>>>(
            async matchedUserId => await _accessPermissionManager.GrantAsync(matchedUserId, new TimeSpan(0, 0, 69)), // TODO: use configuration value
            notFound => AccessDeniedResult,
            mismatched => AccessDeniedResult);
    }
}