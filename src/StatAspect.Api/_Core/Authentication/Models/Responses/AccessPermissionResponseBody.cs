namespace StatAspect.Api._Core.Authentication.Models.Responses;

/// <summary>
/// An access permission response body.
/// </summary>
public sealed class AccessPermissionResponseBody
{
    /// <summary>
    /// An access permission token.
    /// </summary>
    /// <example>eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c</example>
    [JsonProperty("token")]
    [Required]
    public string Token { get; }

    /// <summary>
    /// An access permission issue date.
    /// </summary>
    /// <example>2023-10-08T09:09:36.7008126+04:00</example>
    [JsonProperty("issueDate")]
    [Required]
    public DateTime IssueDate { get; }

    /// <summary>
    /// An access permission expiration date.
    /// </summary>
    /// <example>2023-10-08T21:09:36.7008126+04:00</example>
    [JsonProperty("expirationDate")]
    [Required]
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