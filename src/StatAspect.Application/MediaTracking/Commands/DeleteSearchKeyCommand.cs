namespace StatAspect.Application.MediaTracking.Commands;

/// <summary>
/// Represents a command to delete a search key.
/// </summary>
public sealed class DeleteSearchKeyCommand : IRequest
{
    /// <summary>
    /// Gets the target search key identifier.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Initializes a new <see cref="DeleteSearchKeyCommand"/> instance.
    /// </summary>
    public DeleteSearchKeyCommand(int id)
    {
        Id = id;
    }
}