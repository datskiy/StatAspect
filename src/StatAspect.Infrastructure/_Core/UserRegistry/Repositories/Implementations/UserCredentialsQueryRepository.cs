using StatAspect.Domain._Core.UserRegistry.Aggregates;
using StatAspect.Domain._Core.UserRegistry.Repositories;
using StatAspect.Domain._Core.UserRegistry.ValueObjects;
using StatAspect.Domain._Core.UserRegistry.ValueObjects.Identifiers;

namespace StatAspect.Infrastructure._Core.UserRegistry.Repositories.Implementations;

public sealed class UserCredentialsQueryRepository : IUserCredentialsQueryRepository
{
    public Task<UserCredentials?> GetSingleAsync(Username username, CancellationToken cancellationToken = default) // TODO: implement
    {
        ArgumentNullException.ThrowIfNull(username);

        return Task.FromResult((UserCredentials?)new UserCredentials(
            new UserId(Guid.NewGuid()),
            username,
            new PasswordHash("VGhpcyBpcyBhIHRlc3Qgc3RyaW5nLg=="),
            new PasswordSalt("VGhpcyBpcyBhIHRlc3Qgc3RyaW5nLg==")));
    }
}