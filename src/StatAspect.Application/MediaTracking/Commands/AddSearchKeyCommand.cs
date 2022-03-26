using StatAspect.Domain.MediaTracking.Identifiers;
using StatAspect.SharedKernel.Markers;

namespace StatAspect.Application.MediaTracking.Commands;

/// <summary>
/// Represents a command to add a new search key.
/// </summary>
public sealed class AddSearchKeyCommand : IRequest<OneOf<SearchKeyId, AlreadyExists>>
{
    /// <summary>
    /// Gets the name of the new search key.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the description of the new search key.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="AddSearchKeyCommand"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public AddSearchKeyCommand(string name, string? description)
    {
        Guard.Argument(() => name).NotNull();

        Name = name;
        Description = description;
    }
}