namespace StatAspect.Domain._Core.UserRegistry.Specifications;

/// <summary>
/// Provides a specification that describes user credentials constraints.
/// </summary>
public static class UserCredentialsSpecification
{
    /// <summary>
    /// The maximum length of a username.
    /// </summary>
    public const int UsernameMaxLength = 30;

    /// <summary>
    /// The maximum length of a password.
    /// </summary>
    public const int PasswordMinLength = 9;
}