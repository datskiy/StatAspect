namespace StatAspect.Api.MediaTracking.Models.Responses;

/// <summary>
/// Represents a search key response body.
/// </summary>
public sealed class SearchKeyResponseBody
{
    /// <summary>
    /// Gets a search key unique identifier.
    /// </summary>
    [JsonProperty("id")]
    public Guid Id { get; }

    /// <summary>
    /// Gets a search key name.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; }

    /// <summary>
    /// Gets a search key description.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; }

    /// <summary>
    /// Gets a search key creation date.
    /// </summary>
    [JsonProperty("creationDate")]
    public DateTime CreationDate { get; }

    /// <summary>
    /// Gets a search key last update date.
    /// </summary>
    [JsonProperty("lastUpdateDate")]
    public DateTime? LastUpdateDate { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="SearchKeyResponseBody"/>.
    /// </summary>
    public SearchKeyResponseBody(Guid id, string name, string? description, DateTime creationDate, DateTime? lastUpdateDate)
    {
        Id = id;
        Name = name;
        Description = description;
        CreationDate = creationDate;
        LastUpdateDate = lastUpdateDate;
    }
}