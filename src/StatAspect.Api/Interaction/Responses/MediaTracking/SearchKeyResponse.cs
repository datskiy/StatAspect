﻿namespace StatAspect.Api.Interaction.Responses.MediaTracking;

/// <summary>
/// Search key response model.
/// </summary>
public sealed class SearchKeyResponse
{
    /// <summary>
    /// A unique identifier for the current search key.
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// Name of the search key.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Description of the search key.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Creation date of the current search key.
    /// </summary>
    [JsonProperty("creationDate")]
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// The date the current search key was last updated.
    /// </summary>
    [JsonProperty("lastUpdateDate")]
    public DateTime? LastUpdateDate { get; set; }
}