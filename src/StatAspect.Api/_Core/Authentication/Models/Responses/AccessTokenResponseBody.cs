namespace StatAspect.Api._Core.Authentication.Models.Responses;

/// <summary>
/// Represents a search key response body. // TODO: desc
/// </summary>
public sealed class AccessPermissionResponseBody
{
    /// <summary>
    /// Gets an access permission token.
    /// </summary>
    [JsonProperty("token")]
    public string Token { get; }
    
    /// <summary>
    /// Gets an access permission issue date.
    /// </summary>
    [JsonProperty("issueDate")]
    public DateTime IssueDate { get; }

    /// <summary>
    /// Gets an access permission expiration date.
    /// </summary>
    [JsonProperty("expirationDate")]
    public DateTime ExpirationDate { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="AccessPermissionResponseBody"/>.
    /// </summary>
    public AccessPermissionResponseBody(string token, DateTime issueDate, DateTime expirationDate)
    {
        Token = token;
        IssueDate = issueDate;
        ExpirationDate = expirationDate;
    }
}