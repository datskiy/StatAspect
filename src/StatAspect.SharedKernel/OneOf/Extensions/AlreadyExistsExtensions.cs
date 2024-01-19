using StatAspect.SharedKernel.OneOf.Results;
using StatAspect.SharedKernel.OneOf.Results.TargetProperties.Abstractions;

namespace StatAspect.SharedKernel.OneOf.Extensions;

/// <summary>
/// Provides a set of extension methods for <see cref="AlreadyExists{TProp}"/>.
/// </summary>
public static class AlreadyExistsExtensions
{
    /// <summary>
    /// Returns a display name of a property that is targeted by the specified result.
    /// </summary>
    public static string GetTargetPropertyDisplayName<TProp>(this AlreadyExists<TProp> result)
        where TProp : struct, IResultTargetPropertyName
    {
        return result
            .GetType()
            .GetGenericArguments()[0].Name
            .ToLower();
    }
}