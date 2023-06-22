namespace StatAspect.Api.MediaTracking.Models.Requests;

/// <summary>
/// Represents a new search key request model.
/// </summary>
public sealed class NewSearchKeyRequestBody
{
    /// <summary>
    /// Gets or inits a name of the new search key.
    /// </summary>
    [JsonProperty("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Gets or inits a description of the new search key.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; init; }
}