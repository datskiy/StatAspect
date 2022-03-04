﻿namespace StatAspect.Application.Commands.MediaTracking;

/// <summary>
/// Represents a command to add a new search key.
/// </summary>
public sealed class AddSearchKeyCommand : IRequest<int>
{
    /// <summary>
    /// Gets the name of the new search key.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets the description of the new search key.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Initializes a new <see cref="AddSearchKeyCommand"/> instance.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public AddSearchKeyCommand(string name, string? description)
    {
        Guard.Argument(() => name).NotNull();

        Name = name;
        Description = description;
    }
}