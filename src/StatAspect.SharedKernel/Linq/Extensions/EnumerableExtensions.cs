namespace StatAspect.SharedKernel.Linq.Extensions;

/// <summary>
/// Provides a set of extension methods for types that implement <see cref="IEnumerable{T}"/>.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Determines whether a sequence contains no elements.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static bool None<T>(this IEnumerable<T> source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return !source.Any();
    }
}