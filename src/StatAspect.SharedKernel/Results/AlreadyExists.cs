// ReSharper disable UnusedTypeParameter

using StatAspect.SharedKernel.Results.TargetProperties.Abstractions;

namespace StatAspect.SharedKernel.Results;

/// <summary>
/// Represents an <see cref="AlreadyExists{TPropName}"/> result.
/// </summary>
public struct AlreadyExists<TPropName> where TPropName : struct, IResultTargetPropertyName
{
}