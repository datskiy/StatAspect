namespace StatAspect.Api.General.Models.Response;

/// <summary>
/// Represents a unified invalid operation response model.
/// </summary>
public sealed class InvalidOperationResponse
{
    /// <summary>
    /// Gets an error title.
    /// </summary>
    [JsonProperty("title")]
    public string Title => "Invalid operation attempt declined.";

    /// <summary>
    /// Gets or inits an error description.
    /// </summary>
    [JsonProperty("error")]
    public required string Error { get; init; }
}