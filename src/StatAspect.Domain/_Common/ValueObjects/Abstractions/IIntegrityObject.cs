namespace StatAspect.Domain._Common.ValueObjects.Abstractions;

/// <summary>
/// ***
/// </summary>
public interface IIntegrityObject<in T>
{
    /// <summary>
    /// ***
    /// </summary>
    static abstract IValidator<T> GetValidator(string? paramName = null);
}