using StatAspect.Api._Common.Formatters.Providers;

namespace StatAspect.Api._Common.Formatters;

/// <summary>
/// Represents a property-based JSON metadata formatter.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class JsonPropertyMetadataFormatter : IConfigureOptions<MvcOptions>
{
    private readonly IOptions<JsonOptions> _jsonOptions;

    public JsonPropertyMetadataFormatter(IOptions<JsonOptions> jsonOptions)
    {
        _jsonOptions = jsonOptions;
    }

    public void Configure(MvcOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        var namingPolicy = _jsonOptions.Value.JsonSerializerOptions.PropertyNamingPolicy!;
        options.ModelMetadataDetailsProviders.Add(new JsonPropertyMetadataProvider(namingPolicy));
    }
}