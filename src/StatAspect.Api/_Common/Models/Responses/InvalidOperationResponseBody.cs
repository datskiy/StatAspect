namespace StatAspect.Api._Common.Models.Responses;

/// <summary>
/// Represents an invalid operation response body.
/// </summary>
public sealed class InvalidOperationResponseBody
{
    /// <summary>
    /// Gets a default error title.
    /// </summary>
    [JsonProperty("title")]
    public string Title => "Invalid operation attempt declined.";

    /// <summary>
    /// Gets an error description.
    /// </summary>
    [JsonProperty("error")]
    public string Error { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="InvalidOperationResponseBody"/>.
    /// </summary>
    public InvalidOperationResponseBody(string error)
    {
        Error = error;
    }
}