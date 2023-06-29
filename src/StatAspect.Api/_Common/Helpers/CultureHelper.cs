namespace StatAspect.Api._Common.Helpers;

/// <summary>
/// Provides static utility methods for working with culture information.
/// </summary>
public static class CultureHelper
{
    private const string LocalizationCultureName = "en";

    /// <summary>
    /// Returns default localization culture.
    /// </summary>
    public static CultureInfo GetLocalizationCulture()
    {
        return new CultureInfo(LocalizationCultureName);
    }
}