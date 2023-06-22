namespace StatAspect.Api._Common.Models.Responses;

/// <summary>
/// Represents a unified validation failure response model.
/// </summary>
public sealed class ValidationFailureResponseBody
{
    /// <summary>
    /// Gets a failure type.
    /// </summary>
    [JsonProperty("type")]
    public string Type => "https://tools.ietf.org/html/rfc7231#section-6.5.1";

    /// <summary>
    /// Gets a failure title.
    /// </summary>
    [JsonProperty("title")]
    public string Title => "One or more validation errors occurred.";

    /// <summary>
    /// Gets a failure status code.
    /// </summary>
    [JsonProperty("status")]
    public int StatusCode => StatusCodes.Status400BadRequest;

    /// <summary>
    /// Gets a failure related request unique identifier.
    /// </summary>
    [JsonProperty("traceId")]
    public string TraceId => Activity.Current!.Id!;

    /// <summary>
    /// Gets or inits a failure related collection of errors.
    /// </summary>
    [JsonProperty("errors")]
    public required IEnumerable<KeyValuePair<string, string[]>> Errors { get; init; }
}