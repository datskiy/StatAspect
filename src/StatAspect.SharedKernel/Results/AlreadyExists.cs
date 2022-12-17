using StatAspect.SharedKernel.Results.Properties.Abstractions;

namespace StatAspect.SharedKernel.Results;

public struct AlreadyExists<T> where T : struct, IResultPropertyName
{
}