namespace StatAspect.Api._Common.Extensions;

/// <summary>
/// Provides a set of extension methods for <see cref="ValidationFailure"/>.
/// </summary>
public static class ValidationFailureExtensions
{
    /// <summary>
    /// Creates a <see cref="ModelStateDictionary"/> from the sequence of validation failures.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static ModelStateDictionary ToModelStateDictionary(this IEnumerable<ValidationFailure> validationFailures)
    {
        ArgumentNullException.ThrowIfNull(validationFailures);

        var modelStateDictionary = new ModelStateDictionary();
        foreach (var validationFailure in validationFailures)
            modelStateDictionary.AddModelError(validationFailure.PropertyName, validationFailure.ErrorMessage);

        return modelStateDictionary;
    }
}