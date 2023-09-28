using StatAspect.Domain._Common.ValueObjects.Abstractions;
using StatAspect.Domain.MediaTracking.Validators;

namespace StatAspect.Domain.MediaTracking.ValueObjects;

/// <summary>
/// Represents a search key name.
/// </summary>
public sealed record SearchKeyName : ValueObject<string>, IIntegrityEnsurer<string>
{
    /// <summary>
    /// Initializes a new instance of <see cref="SearchKeyName"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    public SearchKeyName(string value) : base(value, GetValidator())
    {
    }

    public static IValidator<string> GetValidator(string? paramName = null)
    {
        return new SearchKeyNameValidator(paramName ?? nameof(SearchKeyName));
    }
}