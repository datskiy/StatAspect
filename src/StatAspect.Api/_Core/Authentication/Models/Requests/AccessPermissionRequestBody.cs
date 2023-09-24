namespace StatAspect.Api._Core.Authentication.Models.Requests;

/// <summary>
/// Represents an access permission request body.
/// </summary>
public sealed class AccessPermissionRequestBody
{
    /// <summary>
    /// Gets or inits a username.
    /// </summary>
    [JsonProperty("username")]
    public string Username { get; init; }

    /// <summary>
    /// Gets or inits a user password.
    /// </summary>
    [JsonProperty("password")]
    public string Password { get; init; }
}