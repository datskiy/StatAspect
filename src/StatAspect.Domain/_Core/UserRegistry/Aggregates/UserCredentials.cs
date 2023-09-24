using StatAspect.Domain._Core.UserRegistry.ValueObjects;
using StatAspect.Domain._Core.UserRegistry.ValueObjects.Identifiers;

namespace StatAspect.Domain._Core.UserRegistry.Aggregates;

/// <summary>
/// Represents user credentials.
/// </summary>
public sealed class UserCredentials
{
    /// <summary>
    /// Gets a unique user identifier.
    /// </summary>
    public UserId UserId { get; }

    /// <summary>
    /// Gets a username.
    /// </summary>
    public Username Username { get; }

    /// <summary>
    /// Gets a password hash.
    /// </summary>
    public PasswordHash PasswordHash { get; }

    /// <summary>
    /// Gets a password salt.
    /// </summary>
    public PasswordSalt PasswordSalt { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="UserCredentials"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public UserCredentials(
        UserId userId,
        Username username,
        PasswordHash passwordHash,
        PasswordSalt passwordSalt)
    {
        ArgumentNullException.ThrowIfNull(userId);
        ArgumentNullException.ThrowIfNull(username);
        ArgumentNullException.ThrowIfNull(passwordHash);
        ArgumentNullException.ThrowIfNull(passwordSalt);

        UserId = userId;
        Username = username;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
}