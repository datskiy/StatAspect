namespace StatAspect.Api.General.Helpers;

/// <summary>
/// XXX
/// </summary>
public static class CultureHelper
{
    private static readonly CultureInfo globalCulture = new("en");

    /// <summary>
    /// XXX
    /// </summary>
    public static CultureInfo GetGlobalCulture()
    {
        return globalCulture;
    }
}