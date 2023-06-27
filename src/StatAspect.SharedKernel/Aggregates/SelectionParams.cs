namespace StatAspect.SharedKernel.Aggregates;

/// <summary>
/// Represents collection selection params.
/// </summary>
public sealed class SelectionParams // TODO: implement, tests
{
    /// <summary>
    /// Gets selection offset.
    /// </summary>
    public int Offset { get; }

    /// <summary>
    /// Gets selection limit.
    /// </summary>
    public int Limit { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="SelectionParams"/>.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public SelectionParams(int offset = 0, int limit = int.MaxValue)
    {
        Guard.Argument(() => offset).NotNegative();
        Guard.Argument(() => limit).GreaterThan(default);

        Offset = offset;
        Limit = limit;
    }
}