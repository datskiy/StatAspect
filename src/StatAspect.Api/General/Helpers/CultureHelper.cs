namespace StatAspect.Api.General.Helpers;

/// <summary>
/// Provides static methods for accessing culture information.
/// </summary>
public static class CultureHelper
{
    private const string GlobalCultureName = "en";

    /// <summary>
    /// Returns the global culture.
    /// </summary>
    public static CultureInfo GetGlobalCulture()
    {
        return new CultureInfo(GlobalCultureName);
    }
}