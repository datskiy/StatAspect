namespace StatAspect.Api.Interaction.Requests.MediaTracking;

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