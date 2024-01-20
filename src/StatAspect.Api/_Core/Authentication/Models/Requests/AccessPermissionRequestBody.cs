using StatAspect.Domain._Core.UserRegistry.Specifications;

namespace StatAspect.Api._Core.Authentication.Models.Requests;

/// <summary>
/// An access permission request body.
/// </summary>
public sealed class AccessPermissionRequestBody
{
    /// <summary>
    /// The target username.
    /// </summary>
    /// <example>JohnSmith</example>
    [JsonProperty("username")]
    [Required]
    [MaxLength(UserCredentialsSpecification.UsernameMaxLength)]
    public string Username { get; }

    /// <summary>
    /// The target password.
    /// </summary>
    /// <example>VeryComplexTestPassword</example>
    [JsonProperty("password")]
    [Required]
    [MinLength(UserCredentialsSpecification.PasswordMinLength)]
    public string Password { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="AccessPermissionRequestBody"/>.
    /// </summary>
    public AccessPermissionRequestBody([MaybeNull] string username, [MaybeNull] string password)
    {
        Username = username;
        Password = password;
    }
}