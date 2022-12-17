namespace StatAspect.Api.General.Extensions;

/// <summary>
/// Provides a set of extension methods for <see cref="ValidationException"/> objects.
/// </summary>
public static class ValidationExceptionExtensions
{
    /// <summary>
    /// Returns a field-based dictionary of validation errors retrieved from the target <see cref="ValidationException"/> instance.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static IImmutableDictionary<string, string[]> ToDictionary(this ValidationException ex)
    {
        Guard.Argument(() => ex).NotNull();

        return ex.Errors
            .GroupBy(flr => flr.PropertyName)
            .Select(grp => new
            {
                PropertyName = grp.Key,
                ErrorMessages = ex.Errors
                    .Where(flr => flr.PropertyName == grp.Key)
                    .Select(flr => flr.ErrorMessage)
            })
            .ToImmutableDictionary(key => key.PropertyName, val => val.ErrorMessages.ToArray());
    }
}