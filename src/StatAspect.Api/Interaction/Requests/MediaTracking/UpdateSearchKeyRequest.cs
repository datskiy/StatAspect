namespace StatAspect.Api.Interaction.Requests.MediaTracking;

public sealed class UpdateSearchKeyRequest
{
    [JsonProperty("value")]
    public string Value { get; set; }
}