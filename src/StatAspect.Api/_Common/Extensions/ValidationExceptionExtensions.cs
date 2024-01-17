using ValidationException = FluentValidation.ValidationException;

namespace StatAspect.Api._Common.Extensions;

/// <summary>
/// Provides a set of extension methods for <see cref="ValidationException"/>.
/// </summary>
public static class ValidationExceptionExtensions
{
    /// <summary>
    /// Returns a field-based dictionary of validation errors constructed from the specified <see cref="ValidationException"/> instance.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static IImmutableDictionary<string, string[]> ToErrorImmutableDictionary(this ValidationException ex)
    {
        ArgumentNullException.ThrowIfNull(ex);

        return ex.Errors
            .GroupBy(failure => failure.PropertyName)
            .Select(grp => new
            {
                PropertyName = grp.Key,
                ErrorMessages = ex.Errors
                    .Where(failure => failure.PropertyName == grp.Key)
                    .Select(failure => failure.ErrorMessage)
            })
            .ToImmutableDictionary(
                key => key.PropertyName,
                val => val.ErrorMessages.ToArray());
    }
}