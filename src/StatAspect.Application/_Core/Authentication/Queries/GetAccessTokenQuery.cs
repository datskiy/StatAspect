using StatAspect.Domain._Core.Authentication.Aggregates;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Application._Core.Authentication.Queries;

/// <summary>
/// Represents a query for getting a generated user access token.
/// </summary>
public sealed class GetAccessTokenQuery : IRequest<OneOf<AccessToken, AccessDenied>>
{
    /// <summary>
    /// Gets user's name.
    /// </summary>
    public string Username { get; }

    /// <summary>
    /// Gets user's password.
    /// </summary>
    public string Password { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="GetAccessTokenQuery"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public GetAccessTokenQuery(string username, string password)
    {
        Guard.Argument(() => username).NotNull();
        Guard.Argument(() => password).NotNull();

        Username = username;
        Password = password;
    }
}