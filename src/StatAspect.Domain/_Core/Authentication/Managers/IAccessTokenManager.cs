using StatAspect.Domain._Core.Authentication.Aggregates;
using StatAspect.Domain._Core.UserRegistry.ValueObjects.Identifiers;

namespace StatAspect.Domain._Core.Authentication.Managers;

/// <summary>
/// Represents an access token manager.
/// </summary>
public interface IAccessTokenManager
{
    /// <summary>
    /// Generates and returns an access token for the specified user.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    Task<AccessToken> IssueAsync(UserId userId, TimeSpan duration);
}