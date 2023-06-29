namespace StatAspect.Api._Core.Authentication.Models.Requests;

/// <summary>
/// Represents an access token request body.
/// </summary>
public sealed class AccessTokenRequestBody
{
    /// <summary>
    /// Gets or inits a username.
    /// </summary>
    [JsonProperty("username")]
    public required string Username { get; init; }

    /// <summary>
    /// Gets or inits a user password.
    /// </summary>
    [JsonProperty("password")]
    public required string Password { get; init; }
}