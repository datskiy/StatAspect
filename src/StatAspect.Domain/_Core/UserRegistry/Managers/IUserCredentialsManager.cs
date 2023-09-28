using StatAspect.Domain._Core.UserRegistry.ValueObjects;
using StatAspect.Domain._Core.UserRegistry.ValueObjects.Identifiers;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Domain._Core.UserRegistry.Managers;

/// <summary>
/// Defines a user credentials manager.
/// </summary>
public interface IUserCredentialsManager
{
    /// <summary>
    /// Verifies that the provided username and password belong to an existing user and returns matched user credentials.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    Task<OneOf<UserId, NotFound, Mismatched>> VerifyAsync(Username username, Password password, CancellationToken cancellationToken = default);
}