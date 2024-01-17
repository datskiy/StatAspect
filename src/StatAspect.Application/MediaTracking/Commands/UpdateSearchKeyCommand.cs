using StatAspect.SharedKernel.OneOf.Results;
using StatAspect.SharedKernel.OneOf.Results.TargetProperties;

namespace StatAspect.Application.MediaTracking.Commands;

/// <summary>
/// Represents a search key update command.
/// </summary>
public sealed class UpdateSearchKeyCommand : IRequest<OneOf<Success, NotFound, AlreadyExists<Name>>>
{
    /// <summary>
    /// Gets the target search key identifier.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets a modified search key name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets a modified search key description.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="UpdateSearchKeyCommand"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public UpdateSearchKeyCommand(Guid id, string name, string? description)
    {
        ArgumentNullException.ThrowIfNull(name);

        Id = id;
        Name = name;
        Description = description;
    }
}