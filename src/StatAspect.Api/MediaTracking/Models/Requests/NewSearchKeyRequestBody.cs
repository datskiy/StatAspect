namespace StatAspect.Api.MediaTracking.Models.Requests;

/// <summary>
/// Represents a new search key request body.
/// </summary>
public sealed class NewSearchKeyRequestBody
{
    /// <summary>
    /// Gets or inits a new search key name.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; init; }

    /// <summary>
    /// Gets or inits a new search key description.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; init; }
}