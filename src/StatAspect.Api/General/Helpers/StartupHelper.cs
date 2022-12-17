using StatAspect.Application;

namespace StatAspect.Api.General.Helpers;

/// <summary>
/// Provides static utility methods for working with startup process.
/// </summary>
public static class StartupHelper
{
    /// <summary>
    /// Returns the API layer default initialization type.
    /// </summary>
    public static Type GetApiLayerInitType()
    {
        return typeof(Startup);
    }

    /// <summary>
    /// Returns the application layer default initialization type.
    /// </summary>
    public static Type GetApplicationLayerInitType()
    {
        return typeof(ApplicationInit);
    }
}