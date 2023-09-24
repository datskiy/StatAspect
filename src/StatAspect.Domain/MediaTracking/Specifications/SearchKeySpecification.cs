namespace StatAspect.Domain.MediaTracking.Specifications;

/// <summary>
/// Provides a specification that describes search key constraints.
/// </summary>
public static class SearchKeySpecification
{
    /// <summary>
    /// The maximum length of a search key name.
    /// </summary>
    public const int MaxNameLength = 50;

    /// <summary>
    /// The maximum length of a search key description.
    /// </summary>
    public const int MaxDescriptionLength = 300;
}