namespace StatAspect.Api.MediaTracking.Models.Requests;

/// <summary>
/// A new search key request model.
/// </summary>
public sealed class AddSearchKeyRequest
{
    /// <summary>
    /// A name of the new search key.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; init; }

    /// <summary>
    /// A description of the new search key.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; init; }
}