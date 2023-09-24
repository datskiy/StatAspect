using StatAspect.Domain._Common.ValueObjects.Abstractions;
using StatAspect.Domain.MediaTracking.Validators;

namespace StatAspect.Domain.MediaTracking.ValueObjects;

public record SearchKeyDescription : ValueObject<string>, IIntegrityObject<string>
{
    public SearchKeyDescription(string value) : base(value, GetValidator())
    {
    }

    public static IValidator<string> GetValidator(string? paramName = null)
    {
        return new SearchKeyDescriptionValidator(paramName ?? nameof(SearchKeyDescription));
    }
}