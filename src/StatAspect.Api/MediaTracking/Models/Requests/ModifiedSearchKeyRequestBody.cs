namespace StatAspect.Api.MediaTracking.Models.Requests;

/// <summary>
/// Represents a modified search key request body.
/// </summary>
public sealed class ModifiedSearchKeyRequestBody
{
    /// <summary>
    /// Gets or inits a modified search key name.
    /// </summary>
    [JsonProperty("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Gets or inits a modified search key description.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; init; }
}