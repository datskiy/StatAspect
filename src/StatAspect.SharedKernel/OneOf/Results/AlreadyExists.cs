// ReSharper disable UnusedTypeParameter

using StatAspect.SharedKernel.OneOf.Results.TargetProperties.Abstractions;

namespace StatAspect.SharedKernel.OneOf.Results;

/// <summary>
/// Represents a result that is used when a specified entity already exists in the system.
/// </summary>
public struct AlreadyExists<TProp> where TProp : struct, IResultTargetPropertyName
{
}