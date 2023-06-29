using StatAspect.Api._Common.Controllers.Abstractions;

namespace StatAspect.Api._Common.Helpers;

/// <summary>
/// Provides static utility methods for working with API controllers.
/// </summary>
public static class ControllerHelper
{
    /// <summary>
    /// Returns the first <see cref="RouteAttribute"/> template parameter of the applied controller type, or a default value if no templates parameters were specified.
    /// </summary>
    public static string? GetRouteTemplate<TController>() where TController : BaseController
    {
        return (typeof(TController)
            .GetCustomAttributes(typeof(RouteAttribute), inherit: false)
            .FirstOrDefault() as RouteAttribute)?.Template;
    }
}