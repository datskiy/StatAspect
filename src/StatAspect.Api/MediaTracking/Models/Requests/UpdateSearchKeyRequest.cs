namespace StatAspect.Api.MediaTracking.Models.Requests;

/// <summary>
/// Updated search key request model.
/// </summary>
public sealed class UpdateSearchKeyRequest
{
    /// <summary>
    /// Updated name of the search key.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Updated description of the search key.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; set; }
}