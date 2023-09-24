namespace StatAspect.Api._Core.Authentication.Models.Responses;

/// <summary>
/// Represents a search key response body. // TODO: desc
/// </summary>
public sealed class AccessPermissionResponseBody
{
    /// <summary>
    /// Gets or inits an access permission value.
    /// </summary>
    [JsonProperty("token")]
    public required string Token { get; init; }
    
    /// <summary>
    /// Gets or inits an access permission issue date.
    /// </summary>
    [JsonProperty("issueDate")]
    public DateTime IssueDate { get; init; }

    /// <summary>
    /// Gets or inits an access permission expiration date.
    /// </summary>
    [JsonProperty("expirationDate")]
    public DateTime ExpirationDate { get; init; }
}