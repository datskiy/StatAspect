using StatAspect.Domain._Core.Authentication.Aggregates;
using StatAspect.Domain._Core.UserRegistry.ValueObjects.Identifiers;

namespace StatAspect.Domain._Core.Authentication.Managers;

/// <summary>
/// Represents an access permission manager. // TODO: desc
/// </summary>
public interface IAccessPermissionManager
{
    /// <summary>
    /// Generates and returns an access permission for the specified user.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    Task<AccessPermission> GrantAsync(UserId userId, TimeSpan duration);
}