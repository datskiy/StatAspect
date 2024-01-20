using StatAspect.Application._Common.Pipelines.Responses;
using StatAspect.SharedKernel.OneOf.Results;
using StatAspect.SharedKernel.OneOf.Results.TargetProperties;

namespace StatAspect.Application.MediaTracking.Commands;

/// <summary>
/// Represents a search key update command.
/// </summary>
public sealed class UpdateSearchKeyCommand : IRequest<PipelineResponse<OneOf<Success, NotFound, AlreadyExists<Name>>>>
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
    public UpdateSearchKeyCommand(Guid id, [MaybeNull] string name, string? description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}