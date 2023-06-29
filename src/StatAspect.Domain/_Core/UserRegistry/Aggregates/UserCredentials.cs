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
    public string Username { get; }

    /// <summary>
    /// Gets a password hash.
    /// </summary>
    public string PasswordHash { get; } // TODO: to password value object

    /// <summary>
    /// Gets a password salt.
    /// </summary>
    public string PasswordSalt { get; } // TODO: to password value object (SecurePassword?)

    /// <summary>
    /// Initializes a new instance of <see cref="UserCredentials"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public UserCredentials(
        UserId userId,
        string username,
        string passwordHash,
        string passwordSalt)
    {
        Guard.Argument(() => userId).NotNull();
        Guard.Argument(() => username).NotNull();
        Guard.Argument(() => passwordHash).NotNull();
        Guard.Argument(() => passwordSalt).NotNull();

        UserId = userId;
        Username = username;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
}