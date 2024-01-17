using StatAspect.Domain.MediaTracking.Specifications;

namespace StatAspect.Api.MediaTracking.Models.Responses;

/// <summary>
/// A search key response body.
/// </summary>
public sealed class SearchKeyResponseBody
{
    /// <summary>
    /// A search key unique identifier.
    /// </summary>
    /// <example>9AE98FF4-611B-44FC-8B1E-FAF754E3CB4D</example>
    [JsonProperty("id")]
    [Required]
    public Guid Id { get; }

    /// <summary>
    /// A search key name.
    /// </summary>
    /// <example>Test name</example>
    [JsonProperty("name")]
    [Required]
    [MaxLength(SearchKeySpecification.NameMaxLength)]
    public string Name { get; }

    /// <summary>
    /// A search key description.
    /// </summary>
    /// <example>Test description</example>
    [JsonProperty("description")]
    [MaxLength(SearchKeySpecification.DescriptionMaxLength)]
    public string? Description { get; }

    /// <summary>
    /// A search key creation date.
    /// </summary>
    /// <example>2023-07-07T17:22:03.7008126+04:00</example>
    [JsonProperty("creationDate")]
    [Required]
    public DateTime CreationDate { get; }

    /// <summary>
    /// A search key last update date.
    /// </summary>
    /// <example>2023-10-08T21:09:36.7008126+04:00</example>
    [JsonProperty("lastUpdateDate")]
    public DateTime? LastUpdateDate { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="SearchKeyResponseBody"/>.
    /// </summary>
    public SearchKeyResponseBody(Guid id, string name, string? description, DateTime creationDate, DateTime? lastUpdateDate)
    {
        Id = id;
        Name = name;
        Description = description;
        CreationDate = creationDate;
        LastUpdateDate = lastUpdateDate;
    }
}