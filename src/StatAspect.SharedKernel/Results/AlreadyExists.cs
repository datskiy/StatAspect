using StatAspect.SharedKernel.Results.Properties.Abstractions;

namespace StatAspect.SharedKernel.Results;

public struct AlreadyExists<TPropName> where TPropName : struct, IResultPropertyName
{
}