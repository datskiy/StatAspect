namespace StatAspect.Api._Common.Models.Responses;

/// <summary>
/// Represents a validation failure response body.
/// </summary>
public sealed class ValidationFailureResponseBody
{
    /// <summary>
    /// Gets a default failure type.
    /// </summary>
    [JsonProperty("type")]
    public string Type => "https://tools.ietf.org/html/rfc7231#section-6.5.1";

    /// <summary>
    /// Gets a default failure title.
    /// </summary>
    [JsonProperty("title")]
    public string Title => "One or more validation errors occurred.";

    /// <summary>
    /// Gets a default failure status code.
    /// </summary>
    [JsonProperty("status")]
    public int StatusCode => StatusCodes.Status400BadRequest;

    /// <summary>
    /// Gets a current trace unique identifier.
    /// </summary>
    [JsonProperty("traceId")]
    public string TraceId => Activity.Current!.Id!;

    /// <summary>
    /// Gets a sequence of errors.
    /// </summary>
    [JsonProperty("errors")]
    public IEnumerable<KeyValuePair<string, string[]>> Errors { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="ValidationFailureResponseBody"/>.
    /// </summary>
    public ValidationFailureResponseBody(IEnumerable<KeyValuePair<string, string[]>> errors)
    {
        Errors = errors;
    }
}