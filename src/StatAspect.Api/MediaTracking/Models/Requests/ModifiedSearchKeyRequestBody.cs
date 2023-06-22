namespace StatAspect.Api.MediaTracking.Models.Requests;

/// <summary>
/// Represents a modified search key request model.
/// </summary>
public sealed class ModifiedSearchKeyRequestBody
{
    /// <summary>
    /// Gets or inits a modified name of the search key.
    /// </summary>
    [JsonProperty("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Gets or inits a modified description of the search key.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; init; }
}