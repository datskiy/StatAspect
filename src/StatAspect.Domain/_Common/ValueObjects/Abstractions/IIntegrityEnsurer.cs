namespace StatAspect.Domain._Common.ValueObjects.Abstractions;

/// <summary>
/// Defines a generalized method that a <see cref="ValueObject{T}"/> type implements to create a type-specific
/// validation method for ensuring the integrity of its instances.
/// </summary>
public interface IIntegrityEnsurer<in T>
{
    /// <summary>
    /// Returns a type-specific validation method.
    /// A custom parameter name should be specified to associate it with the error message.
    /// </summary>
    static abstract IValidator<T> GetValidator(string? paramName = null);
}