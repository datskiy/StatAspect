using StatAspect.SharedKernel.Results;

namespace StatAspect.Application.MediaTracking.Commands;

/// <summary>
/// Represents a search key deletion command.
/// </summary>
public sealed class DeleteSearchKeyCommand : IRequest<OneOf<Success, NotFound>>
{
    /// <summary>
    /// Gets the target search key identifier.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="DeleteSearchKeyCommand"/>.
    /// </summary>
    public DeleteSearchKeyCommand(Guid id)
    {
        Id = id;
    }
}