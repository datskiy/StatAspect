namespace StatAspect.Api.MediaTracking.Models.Requests;

/// <summary>
/// Represents an updated search key request model.
/// </summary>
public sealed class UpdateSearchKeyRequest
{
    /// <summary>
    /// Gets or inits an updated name of the search key.
    /// </summary>
    [JsonProperty("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Gets or inits an updated description of the search key.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; init; }
}