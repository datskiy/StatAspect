using StatAspect.Domain._Core.UserRegistry.Aggregates;

namespace StatAspect.Domain._Core.UserRegistry.Repositories;

/// <summary>
/// Represents a user credentials query repository.
/// </summary>
public interface IUserCredentialsQueryRepository
{
    /// <summary>
    /// Returns the only user credentials entity corresponding the specified username, otherwise returns null.
    /// Throws an exception if there is more than one element found.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    Task<UserCredentials?> GetSingleAsync(string username, CancellationToken cancellationToken = default);
}