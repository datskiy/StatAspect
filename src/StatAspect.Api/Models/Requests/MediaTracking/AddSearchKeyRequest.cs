namespace StatAspect.Api.Models.Requests.MediaTracking;

/// <summary>
/// XXX
/// </summary>
public sealed class AddSearchKeyRequest
{
    /// <summary>
    /// XXX
    /// </summary>
    [JsonProperty("phrase")]
    public string Phrase { get; set; }
}