// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace StatAspect.Application._Core.Authentication.Options;

/// <summary>
/// Represents a configuration option with authentication policy parameters.
/// </summary>
public sealed class AuthenticationPolicies
{
    /// <summary>
    /// Gets or inits access permission lifetime.
    /// </summary>
    public TimeSpan AccessPermissionLifetime { get; init; }
}