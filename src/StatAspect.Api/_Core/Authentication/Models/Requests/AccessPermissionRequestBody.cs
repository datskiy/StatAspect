namespace StatAspect.Api._Core.Authentication.Models.Requests;

/// <summary>
/// Represents an access permission request body.
/// </summary>
public sealed class AccessPermissionRequestBody
{
    /// <summary>
    /// Gets an access permission username.
    /// </summary>
    [JsonProperty("username")]
    public string Username { get; }

    /// <summary>
    /// Gets a password.
    /// </summary>
    [JsonProperty("password")]
    public string Password { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="AccessPermissionRequestBody"/>.
    /// </summary>
    public AccessPermissionRequestBody(string username, string password)
    {
        Username = username;
        Password = password;
    }
}