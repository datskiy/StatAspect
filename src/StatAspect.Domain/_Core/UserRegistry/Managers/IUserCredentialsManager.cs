using StatAspect.Domain._Core.UserRegistry.Aggregates;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Domain._Core.UserRegistry.Managers;

/// <summary>
/// Represents a user credentials manager.
/// </summary>
public interface IUserCredentialsManager
{
    /// <summary>
    /// Ensures that the provided username and password belong to an existing user and returns matched user credentials.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    Task<OneOf<UserCredentials, NotFound, Mismatched>> VerifyAsync(string username, string password, CancellationToken cancellationToken = default);
}