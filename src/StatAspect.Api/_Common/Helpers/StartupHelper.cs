using StatAspect.Application._Common.Settings;

namespace StatAspect.Api._Common.Helpers;

/// <summary>
/// Provides helper methods for startup.
/// </summary>
public static class StartupHelper
{
    /// <summary>
    /// Returns the <see cref="StatAspect.Api"/> assembly marker type.
    /// </summary>
    public static Type GetApiAssemblyMarkerType()
    {
        return typeof(Startup);
    }

    /// <summary>
    /// Returns the <see cref="StatAspect.Application"/> assembly marker type.
    /// </summary>
    public static Type GetApplicationAssemblyMarkerType()
    {
        return typeof(InterceptingValidationPipelineBehavior<,>);
    }
}