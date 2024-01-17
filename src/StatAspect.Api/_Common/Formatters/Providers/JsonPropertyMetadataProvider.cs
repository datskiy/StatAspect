namespace StatAspect.Api._Common.Formatters.Providers;

/// <summary>
/// Represents a property-based JSON metadata provider.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class JsonPropertyMetadataProvider : IBindingMetadataProvider, IDisplayMetadataProvider
{
    private readonly JsonNamingPolicy _jsonNamingPolicy;

    public JsonPropertyMetadataProvider(JsonNamingPolicy jsonNamingPolicy)
    {
        _jsonNamingPolicy = jsonNamingPolicy;
    }

    public void CreateBindingMetadata(BindingMetadataProviderContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (!context.BindingMetadata.IsBindingAllowed || !IsNonControllerProperty(context.Key))
            return;

        context.BindingMetadata.BinderModelName ??= JsonPropertyName(context.Attributes, context.Key);
    }

    public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (!IsNonControllerProperty(context.Key))
            return;

        context.DisplayMetadata.DisplayName ??= () => JsonPropertyName(context.Attributes, context.Key);
    }

    private static bool IsNonControllerProperty(ModelMetadataIdentity key)
    {
        return key.MetadataKind == ModelMetadataKind.Property && !key.ContainerType!.IsAssignableTo(typeof(ControllerBase));
    }

    private string JsonPropertyName(IEnumerable<object> attributes, ModelMetadataIdentity key)
    {
        return attributes.OfType<JsonPropertyNameAttribute>().FirstOrDefault()?.Name ?? _jsonNamingPolicy.ConvertName(key.Name!);
    }
}