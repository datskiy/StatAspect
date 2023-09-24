using StatAspect.Domain._Core.Authentication.ValueObjects;

namespace StatAspect.Domain._Core.Authentication.Aggregates;

/// <summary>
/// Represents an access permission.
/// </summary>
public sealed class AccessPermission
{
    /// <summary>
    /// Gets an access permission string.
    /// </summary>
    public AccessToken Token { get; }

    /// <summary>
    /// Gets an access permission issue date.
    /// </summary>
    public DateTime IssueDate { get; }

    /// <summary>
    /// Gets an access permission expiration date.
    /// </summary>
    public DateTime ExpirationDate { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="AccessPermission"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public AccessPermission(AccessToken token, DateTime issueDate, DateTime expirationDate)
    {
        ArgumentNullException.ThrowIfNull(token);

        Token = token;
        IssueDate = issueDate;
        ExpirationDate = expirationDate;
    }
}