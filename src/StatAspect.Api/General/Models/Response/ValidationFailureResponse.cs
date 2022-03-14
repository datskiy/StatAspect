namespace StatAspect.Api.General.Models.Response;

/// <summary>
/// A validation failure response model.
/// </summary>
public sealed class ValidationFailureResponse
{
    /// <summary>
    /// A failure type.
    /// </summary>
    [JsonProperty("type")]
    public string Type => "https://tools.ietf.org/html/rfc7231#section-6.5.1";

    /// <summary>
    /// A failure title.
    /// </summary>
    [JsonProperty("title")]
    public string Title => "One or more validation errors occurred.";

    /// <summary>
    /// A failure status code.
    /// </summary>
    [JsonProperty("status")]
    public int StatusCode => StatusCodes.Status400BadRequest;

    /// <summary>
    /// A failure related request unique identifier.
    /// </summary>
    [JsonProperty("traceId")]
    public string TraceId => Activity.Current!.Id!;

    /// <summary>
    /// A failure related collection of errors.
    /// </summary>
    [JsonProperty("errors")]
    public IImmutableDictionary<string, string[]> Errors { get; init; }
}