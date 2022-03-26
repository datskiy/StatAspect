namespace StatAspect.SharedKernel.Aggregates;

/// <summary>
/// XXX
/// </summary>
public sealed class SelectionParams
{
    /// <summary>
    /// XXX
    /// </summary>
    public int Offset { get; }

    /// <summary>
    /// XXX
    /// </summary>
    public int Limit { get; }

    /// <summary>
    /// XXX
    /// </summary>
    public SelectionParams(int offset = 0, int limit = int.MaxValue)
    {
        Guard.Argument(() => offset).NotNegative();
        Guard.Argument(() => limit).GreaterThan(default);

        Offset = offset;
        Limit = limit;
    }
}