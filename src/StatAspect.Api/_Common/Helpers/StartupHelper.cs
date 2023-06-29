using StatAspect.Application;

namespace StatAspect.Api._Common.Helpers;

/// <summary>
/// Provides static utility methods for working with startup process.
/// </summary>
public static class StartupHelper
{
    /// <summary>
    /// Returns the <see cref="StatAspect.Api"/> layer default initialization type.
    /// </summary>
    public static Type GetApiLayerInitType()
    {
        return typeof(Startup);
    }

    /// <summary>
    /// Returns the <see cref="StatAspect.Application"/> layer default initialization type.
    /// </summary>
    public static Type GetApplicationLayerInitType()
    {
        return typeof(ApplicationInitializer);
    }
}