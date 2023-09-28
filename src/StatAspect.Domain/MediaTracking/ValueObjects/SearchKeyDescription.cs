using StatAspect.Domain._Common.ValueObjects.Abstractions;
using StatAspect.Domain.MediaTracking.Validators;

namespace StatAspect.Domain.MediaTracking.ValueObjects;

/// <summary>
/// Represents a search key description.
/// </summary>
public sealed record SearchKeyDescription : ValueObject<string>, IIntegrityEnsurer<string>
{
    /// <summary>
    /// Initializes a new instance of <see cref="SearchKeyDescription"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    public SearchKeyDescription(string value) : base(value, GetValidator())
    {
    }

    public static IValidator<string> GetValidator(string? paramName = null)
    {
        return new SearchKeyDescriptionValidator(paramName ?? nameof(SearchKeyDescription));
    }
}