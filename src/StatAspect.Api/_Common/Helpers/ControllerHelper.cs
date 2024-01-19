using StatAspect.Api._Common.Controllers.Abstractions;

namespace StatAspect.Api._Common.Helpers;

/// <summary>
/// Provides helper methods for controllers.
/// </summary>
public static class ControllerHelper
{
    /// <summary>
    /// Returns the first <see cref="RouteAttribute"/> template value of the applied controller type.
    /// If no route templates were specified, returns null.
    /// </summary>
    public static string? GetRouteTemplate<TController>()
        where TController : BaseApiController
    {
        return (typeof(TController)
            .GetCustomAttributes(typeof(RouteAttribute), inherit: false)
            .FirstOrDefault() as RouteAttribute)?.Template;
    }
}