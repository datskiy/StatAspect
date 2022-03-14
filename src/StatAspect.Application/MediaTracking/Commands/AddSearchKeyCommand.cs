using StatAspect.Domain.MediaTracking.Identifiers;

namespace StatAspect.Application.MediaTracking.Commands;

/// <summary>
/// Represents a command to add a new search key.
/// </summary>
public sealed class AddSearchKeyCommand : IRequest<SearchKeyId>
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