namespace StatAspect.Api._Core.Authentication.Models.Responses;

/// <summary>
/// Represents a search key response body.
/// </summary>
public sealed class AccessTokenResponseBody
{
    /// <summary>
    /// Gets or inits an access token value.
    /// </summary>
    [JsonProperty("token")]
    public required string Token { get; init; }
    
    /// <summary>
    /// Gets or inits an access token issue date.
    /// </summary>
    [JsonProperty("issueDate")]
    public DateTime IssueDate { get; init; }

    /// <summary>
    /// Gets or inits an access token expiration date.
    /// </summary>
    [JsonProperty("expirationDate")]
    public DateTime ExpirationDate { get; init; }
}