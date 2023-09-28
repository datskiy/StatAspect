// ReSharper disable UnusedTypeParameter

using StatAspect.SharedKernel.Results.TargetProperties.Abstractions;

namespace StatAspect.SharedKernel.Results;

/// <summary>
/// Represents a result that is used when a specified entity already exists in the system.
/// </summary>
public struct AlreadyExists<TProp> where TProp : struct, IResultTargetPropertyName
{
}