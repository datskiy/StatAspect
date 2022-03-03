namespace StatAspect.Api.Interaction.Requests.MediaTracking;

public sealed class AddSearchKeyRequest
{
    [JsonProperty("value")]
    public string Value { get; set; }
}