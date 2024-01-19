using StatAspect.Domain.MediaTracking.Specifications;

namespace StatAspect.Api.MediaTracking.Models.Requests;

/// <summary>
/// A new search key request body.
/// </summary>
public sealed class NewSearchKeyRequestBody
{
    /// <summary>
    /// A new search key name.
    /// </summary>
    /// <example>Test name</example>
    [JsonProperty("name")]
    [Required]
    [MaxLength(SearchKeySpecification.NameMaxLength)]
    public string Name { get; }

    /// <summary>
    /// A new search key description.
    /// </summary>
    /// <example>Test description</example>
    [JsonProperty("description")]
    [MaxLength(SearchKeySpecification.DescriptionMaxLength)]
    public string? Description { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="NewSearchKeyRequestBody"/>.
    /// </summary>
    public NewSearchKeyRequestBody(string name, string? description)
    {
        Name = name;
        Description = description;
    }
}