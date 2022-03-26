using StatAspect.SharedKernel.Results;

namespace StatAspect.Application.MediaTracking.Commands;

/// <summary>
/// Represents a command to delete a search key.
/// </summary>
public sealed class DeleteSearchKeyCommand : IRequest<OneOf<Success, NotFound>>
{
    /// <summary>
    /// Gets the target search key identifier.
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