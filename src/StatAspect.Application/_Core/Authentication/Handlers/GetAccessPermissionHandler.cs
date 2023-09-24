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
/// Represents an access permission getting request handler.
/// <remarks>Reflection only.</remarks>
/// </summary>
public sealed class GetAccessPermissionHandler : IRequestHandler<GetAccessPermissionQuery, OneOf<AccessPermission, AccessDenied>>
{
    private readonly IUserCredentialsManager _userCredentialsManager;
    private readonly IAccessPermissionManager _accessPermissionManager;

    public GetAccessPermissionHandler(
        IUserCredentialsManager userCredentialsManager,
        IAccessPermissionManager accessPermissionManager)
    {
        _userCredentialsManager = userCredentialsManager;
        _accessPermissionManager = accessPermissionManager;
    }

    private static Task<OneOf<AccessPermission, AccessDenied>> AccessDeniedResult => Task.FromResult<OneOf<AccessPermission, AccessDenied>>(new AccessDenied());

    /// <summary>
    /// Returns a result of processing the <see cref="GetAccessPermissionQuery"/> request.
    /// <remarks>Reflection only.</remarks>
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public async Task<OneOf<AccessPermission, AccessDenied>> Handle(GetAccessPermissionQuery query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query);

        var verificationResult = await _userCredentialsManager.VerifyAsync(
            new Username(query.Username),
            new Password(query.Password),
            cancellationToken);

        return await verificationResult.Match<Task<OneOf<AccessPermission, AccessDenied>>>(
            async matchedUserId => await _accessPermissionManager.GrantAsync(matchedUserId, new TimeSpan(0, 0, 69)),
            notFound => AccessDeniedResult,
            mismatched => AccessDeniedResult);
    }
}