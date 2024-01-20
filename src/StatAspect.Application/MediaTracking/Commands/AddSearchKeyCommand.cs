using StatAspect.Application._Common.Pipelines.Responses;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.OneOf.Results;
using StatAspect.SharedKernel.OneOf.Results.TargetProperties;

namespace StatAspect.Application.MediaTracking.Commands;

/// <summary>
/// Represents a search key addition command.
/// </summary>
public sealed class AddSearchKeyCommand : IRequest<PipelineResponse<OneOf<SearchKeyId, AlreadyExists<Name>>>>
{
    /// <summary>
    /// Gets a new search key name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets a new search key description.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="AddSearchKeyCommand"/>.
    /// </summary>
    public AddSearchKeyCommand([MaybeNull] string name, string? description)
    {
        Name = name;
        Description = description;
    }
}