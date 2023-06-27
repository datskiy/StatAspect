// ReSharper disable UnusedType.Global
// ReSharper disable UnusedParameter.Local

using StatAspect.Application._Core.Authentication.Queries;
using StatAspect.Domain._Core.Authentication.Aggregates;
using StatAspect.Domain._Core.Authentication.Managers;
using StatAspect.Domain._Core.UserRegistry.Managers;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Application._Core.Authentication.Handlers;

/// <summary>
/// Represents an access token getting request handler.
/// <remarks>
/// <list type="bullet">
/// <item>Reflection only.</item>
/// </list>
/// </remarks>
/// </summary>
public sealed class GetAccessTokenHandler : IRequestHandler<GetAccessTokenQuery, OneOf<AccessToken, AccessDenied>>
{
    private readonly IUserCredentialsManager _userCredentialsManager;
    private readonly IAccessTokenManager _accessTokenManager;

    public GetAccessTokenHandler(
        IUserCredentialsManager userCredentialsManager,
        IAccessTokenManager accessTokenManager)
    {
        _userCredentialsManager = userCredentialsManager;
        _accessTokenManager = accessTokenManager;
    }

    private static Task<OneOf<AccessToken, AccessDenied>> AccessDeniedResult => Task.FromResult<OneOf<AccessToken, AccessDenied>>(new AccessDenied());

    /// <summary>
    /// Returns a result of processing the <see cref="GetAccessTokenQuery"/> request.
    /// <remarks>
    /// <list type="bullet">
    /// <item>Reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public async Task<OneOf<AccessToken, AccessDenied>> Handle(GetAccessTokenQuery query, CancellationToken cancellationToken)
    {
        Guard.Argument(() => query).NotNull();

        var verificationResult = await _userCredentialsManager.VerifyAsync(query.Username, query.Password, cancellationToken);
        return await verificationResult.Match<Task<OneOf<AccessToken, AccessDenied>>>(
            async matchedUserCredentials => await _accessTokenManager.IssueAsync(matchedUserCredentials.UserId, new TimeSpan(0, 0, 69)),
            notFound => AccessDeniedResult,
            mismatched => AccessDeniedResult);
    }
}