namespace StatAspect.Api.MediaTracking.Models.Responses;

/// <summary>
/// A search key response model.
/// </summary>
public sealed class SearchKeyResponse
{
    /// <summary>
    /// A unique identifier for the current search key.
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// A name of the search key.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// A description of the search key.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The date the current search key was created.
    /// </summary>
    [JsonProperty("creationDate")]
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// The date the current search key was last updated.
    /// </summary>
    [JsonProperty("lastUpdateDate")]
    public DateTime? LastUpdateDate { get; set; }
}