using StatAspect.Domain._Core.UserRegistry.Aggregates;
using StatAspect.Domain._Core.UserRegistry.ValueObjects;

namespace StatAspect.Domain._Core.UserRegistry.Repositories;

/// <summary>
/// Defines a user credentials query repository.
/// </summary>
public interface IUserCredentialsQueryRepository
{
    /// <summary>
    /// Returns the only user credentials entry that corresponds the specified username, otherwise returns null.
    /// Throws an <see cref="InvalidOperationException"/> if there is more than one element found.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    Task<UserCredentials?> GetSingleAsync(Username username, CancellationToken cancellationToken = default);
}