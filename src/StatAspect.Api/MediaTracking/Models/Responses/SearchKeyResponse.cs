namespace StatAspect.Api.MediaTracking.Models.Responses;

/// <summary>
/// Represents a search key response model.
/// </summary>
public sealed class SearchKeyResponse
{
    /// <summary>
    /// Gets or inits a unique identifier for the current search key.
    /// </summary>
    [JsonProperty("id")]
    public required int Id { get; init; }

    /// <summary>
    /// Gets or inits a name of the search key.
    /// </summary>
    [JsonProperty("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Gets or inits a description of the search key.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; init; }

    /// <summary>
    /// Gets or inits a date the search key was created.
    /// </summary>
    [JsonProperty("creationDate")]
    public required DateTime CreationDate { get; init; }

    /// <summary>
    /// Gets or inits a date the search key was last updated.
    /// </summary>
    [JsonProperty("lastUpdateDate")]
    public DateTime? LastUpdateDate { get; init; }
}