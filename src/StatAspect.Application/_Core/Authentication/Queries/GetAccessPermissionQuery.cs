using StatAspect.Domain._Core.Authentication.Aggregates;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Application._Core.Authentication.Queries;

/// <summary>
/// Represents a query for getting an access permission.
/// </summary>
public sealed class GetAccessPermissionQuery : IRequest<OneOf<AccessPermission, AccessDenied>>
{
    /// <summary>
    /// Gets a username.
    /// </summary>
    public string Username { get; }

    /// <summary>
    /// Gets a password.
    /// </summary>
    public string Password { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="GetAccessPermissionQuery"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public GetAccessPermissionQuery(string username, string password)
    {
        ArgumentNullException.ThrowIfNull(username);
        ArgumentNullException.ThrowIfNull(password);

        Username = username;
        Password = password;
    }
}