using StatAspect.Domain._Core.UserRegistry.Aggregates;
using StatAspect.Domain._Core.UserRegistry.Repositories;
using StatAspect.Domain._Core.UserRegistry.ValueObjects.Identifiers;

namespace StatAspect.Infrastructure._Core.UserRegistry.Repositories.Implementations;

public sealed class UserCredentialsQueryRepository : IUserCredentialsQueryRepository
{
    public Task<UserCredentials?> GetSingleAsync(string username, CancellationToken cancellationToken = default)
    {
        Guard.Argument(() => username).NotNull();

        return Task.FromResult((UserCredentials?)new UserCredentials(new UserId(Guid.NewGuid()), "qwerty", "hashed", "salted"));
    }
}