using StatAspect.Domain._Common.ValueObjects.Abstractions;
using StatAspect.Domain.MediaTracking.Validators;

namespace StatAspect.Domain.MediaTracking.ValueObjects;

/// <summary>
/// ***
/// </summary>
public record SearchKeyName : ValueObject<string>, IIntegrityObject<string>
{
    public SearchKeyName(string value) : base(value, GetValidator())
    {
    }

    public static IValidator<string> GetValidator(string? paramName = null)
    {
        return new SearchKeyNameValidator(paramName ?? nameof(SearchKeyName));
    }
}