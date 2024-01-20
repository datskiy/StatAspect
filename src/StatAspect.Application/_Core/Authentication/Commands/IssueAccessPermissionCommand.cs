using StatAspect.Application._Common.Pipelines.Responses;
using StatAspect.Domain._Core.Authentication.Aggregates;
using StatAspect.SharedKernel.OneOf.Results;

namespace StatAspect.Application._Core.Authentication.Commands;

/// <summary>
/// Represents an access permission issuance command.
/// </summary>
public sealed class IssueAccessPermissionCommand : IRequest<PipelineResponse<OneOf<AccessPermission, AccessDenied>>>
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
    public IssueAccessPermissionCommand([MaybeNull] string username, [MaybeNull] string password)
    {
        Username = username;
        Password = password;
    }
}