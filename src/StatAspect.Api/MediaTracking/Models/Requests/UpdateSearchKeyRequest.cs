namespace StatAspect.Api.MediaTracking.Models.Requests;

/// <summary>
/// An updated search key request model.
/// </summary>
public sealed class UpdateSearchKeyRequest
{
    /// <summary>
    /// An updated name of the search key.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; init; }

    /// <summary>
    /// An updated description of the search key.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; init; }
}