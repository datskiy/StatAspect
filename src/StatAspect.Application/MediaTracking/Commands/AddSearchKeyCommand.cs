using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.Results;
using StatAspect.SharedKernel.Results.TargetProperties;

namespace StatAspect.Application.MediaTracking.Commands;

/// <summary>
/// Represents a search key addition command.
/// </summary>
public sealed class AddSearchKeyCommand : IRequest<OneOf<SearchKeyId, AlreadyExists<Name>>>
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
    /// <exception cref="ArgumentNullException"/>
    public AddSearchKeyCommand(string name, string? description)
    {
        ArgumentNullException.ThrowIfNull(name);

        Name = name;
        Description = description;
    }
}