namespace StatAspect.Api.MediaTracking.Models.Requests;

/// <summary>
/// Represents a new search key request body.
/// </summary>
public sealed class NewSearchKeyRequestBody
{
    /// <summary>
    /// Gets a new search key name.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; }

    /// <summary>
    /// Gets a new search key description.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="NewSearchKeyRequestBody"/>.
    /// </summary>
    public NewSearchKeyRequestBody(string name, string? description)
    {
        Name = name;
        Description = description;
    }
}