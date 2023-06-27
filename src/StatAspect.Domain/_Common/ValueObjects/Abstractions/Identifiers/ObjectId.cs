﻿namespace StatAspect.Domain._Common.ValueObjects.Abstractions.Identifiers;

/// <summary>
/// Represents a base object unique identifier.
/// </summary>
public abstract record ObjectId
{
    private readonly Guid _value;

    /// <exception cref="ArgumentException"/>
    protected ObjectId(Guid value)
    {
        Guard.Argument(() => value).NotEqual(default);

        _value = value;
    }

    public sealed override string ToString()
    {
        return $"{_value}";
    }

    public static explicit operator Guid(ObjectId id) => id._value;
}