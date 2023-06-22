using StatAspect.Api._Common.Controllers.Abstractions;

namespace StatAspect.Api._Common.Helpers;

/// <summary>
/// Provides static utility methods for working with API controllers.
/// </summary>
public static class ControllerHelper
{
    /// <summary>
    /// Returns the first <see cref="RouteAttribute"/> template value of the specified controller.
    /// </summary>
    public static string? GetRouteTemplate<T>() where T : BaseController
    {
        return (typeof(T)
            .GetCustomAttributes(typeof(RouteAttribute), inherit: false)
            .FirstOrDefault() as RouteAttribute)?.Template;
    }
}