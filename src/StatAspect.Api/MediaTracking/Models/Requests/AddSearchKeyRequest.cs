namespace StatAspect.Api.MediaTracking.Models.Requests;

/// <summary>
/// New search key request model.
/// </summary>
public sealed class AddSearchKeyRequest
{
    /// <summary>
    /// Name of the new search key.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Description of the new search key.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; set; }
}