using StatAspect.Domain._Core.Authentication.Aggregates;
using StatAspect.Domain._Core.Authentication.Managers;
using StatAspect.Domain._Core.Authentication.ValueObjects;
using StatAspect.Domain._Core.UserRegistry.ValueObjects.Identifiers;

namespace StatAspect.Infrastructure._Core.Authentication.Managers;

public sealed class AccessPermissionManager : IAccessPermissionManager
{
    public Task<AccessPermission> GrantAsync(UserId userId, TimeSpan duration) // TODO: implement
    {
        ArgumentNullException.ThrowIfNull(userId);

        // TODO: check duration and add either fail result or exception (& include in XML)

        return Task.FromResult(
            new AccessPermission(
                new AccessToken("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"),
                DateTime.Now,
                DateTime.Now.Add(duration)));
    }
}