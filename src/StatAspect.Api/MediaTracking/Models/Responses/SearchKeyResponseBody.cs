namespace StatAspect.Api.MediaTracking.Models.Responses;

/// <summary>
/// Represents a search key response model.
/// </summary>
public sealed class SearchKeyResponseBody
{
    /// <summary>
    /// Gets or inits a search key unique identifier.
    /// </summary>
    [JsonProperty("id")]
    public Guid Id { get; init; }

    /// <summary>
    /// Gets or inits a search key name.
    /// </summary>
    [JsonProperty("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Gets or inits a search key description.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; init; }

    /// <summary>
    /// Gets or inits a search key creation date.
    /// </summary>
    [JsonProperty("creationDate")]
    public DateTime CreationDate { get; init; }

    /// <summary>
    /// Gets or inits a search key last update date.
    /// </summary>
    [JsonProperty("lastUpdateDate")]
    public DateTime? LastUpdateDate { get; init; }
}