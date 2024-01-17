using StatAspect.Domain.MediaTracking.Specifications;

namespace StatAspect.Api.MediaTracking.Models.Requests;

/// <summary>
/// A modified search key request body.
/// </summary>
public sealed class ModifiedSearchKeyRequestBody
{
    /// <summary>
    /// A modified search key name.
    /// </summary>
    /// <example>Test name</example>
    [JsonProperty("name")]
    [Required]
    [MaxLength(SearchKeySpecification.NameMaxLength)]
    public string Name { get; }

    /// <summary>
    /// A modified search key description.
    /// </summary>
    /// <example>Test description</example>
    [JsonProperty("description")]
    [MaxLength(SearchKeySpecification.DescriptionMaxLength)]
    public string? Description { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="ModifiedSearchKeyRequestBody"/>.
    /// </summary>
    public ModifiedSearchKeyRequestBody(string name, string? description)
    {
        Name = name;
        Description = description;
    }
}