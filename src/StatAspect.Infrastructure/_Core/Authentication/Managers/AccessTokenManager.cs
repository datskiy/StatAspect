using StatAspect.Domain._Core.Authentication.Aggregates;
using StatAspect.Domain._Core.Authentication.Managers;
using StatAspect.Domain._Core.UserRegistry.ValueObjects.Identifiers;

namespace StatAspect.Infrastructure._Core.Authentication.Managers;

public sealed class AccessTokenManager : IAccessTokenManager
{
    public Task<AccessToken> IssueAsync(UserId userId, TimeSpan duration)
    {
        Guard.Argument(() => userId).NotNull();
        
        return Task.FromResult(new AccessToken("access-token-123", DateTime.Now, DateTime.Now.AddDays(1))); // TODO: implement
    }
}