using StatAspect.Domain._Core.Authentication.Aggregates;
using StatAspect.SharedKernel.OneOf.Results;

namespace StatAspect.Application._Core.Authentication.Commands;

/// <summary>
/// Represents an access permission issuance command.
/// </summary>
public sealed class IssueAccessPermissionCommand : IRequest<OneOf<AccessPermission, AccessDenied>>
{
    /// <summary>
    /// Gets the target username.
    /// </summary>
    public string Username { get; }

    /// <summary>
    /// Gets the target password.
    /// </summary>
    public string Password { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="IssueAccessPermissionCommand"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public IssueAccessPermissionCommand(string username, string password)
    {
        ArgumentNullException.ThrowIfNull(username);
        ArgumentNullException.ThrowIfNull(password);

        Username = username;
        Password = password;
    }
}