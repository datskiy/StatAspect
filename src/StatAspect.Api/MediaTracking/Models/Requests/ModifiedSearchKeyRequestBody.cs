namespace StatAspect.Api.MediaTracking.Models.Requests;

/// <summary>
/// Represents a modified search key request body.
/// </summary>
public sealed class ModifiedSearchKeyRequestBody
{
    /// <summary>
    /// Gets a modified search key name.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; }

    /// <summary>
    /// Gets a modified search key description.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="ModifiedSearchKeyRequestBody"/>.
    /// </summary>
    public ModifiedSearchKeyRequestBody(string name, string? description)
    {
        Name = name;
        Description = description;
    }
}