namespace StatAspect.Application.MediaTracking.Commands;

/// <summary>
/// Represents a command to delete a search key.
/// </summary>
public sealed class DeleteSearchKeyCommand : IRequest
{
    /// <summary>
    /// Gets the search key identifier.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="DeleteSearchKeyCommand"/>.
    /// </summary>
    public DeleteSearchKeyCommand(int id)
    {
        Id = id;
    }
}