using StatAspect.Domain._Core.Authentication.Aggregates;
using StatAspect.Domain._Core.UserRegistry.ValueObjects.Identifiers;

namespace StatAspect.Domain._Core.Authentication.Managers;

/// <summary>
/// Defines an access permission manager.
/// </summary>
public interface IAccessPermissionManager
{
    /// <summary>
    /// Grants and returns a temporary access permission for the specified user.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    Task<AccessPermission> GrantAsync(UserId userId, TimeSpan lifetime);
}