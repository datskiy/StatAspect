namespace StatAspect.Domain._Core.Authentication.Aggregates;

/// <summary>
/// Represents an access token.
/// </summary>
public sealed class AccessToken
{
    /// <summary>
    /// Gets an access token string.
    /// </summary>
    public string Token { get; }
    
    /// <summary>
    /// Gets an access token issue date.
    /// </summary>
    public DateTime IssueDate { get; }
    
    /// <summary>
    /// Gets an access token expiration date.
    /// </summary>
    public DateTime ExpirationDate { get; }
    
    /// <summary>
    /// Initializes a new instance of <see cref="AccessToken"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public AccessToken(string token, DateTime issueDate, DateTime expirationDate)
    {
        Guard.Argument(() => token).NotNull(); // TODO: validation (exp < issue)
        
        Token = token;
        IssueDate = issueDate;
        ExpirationDate = expirationDate;
    }
}