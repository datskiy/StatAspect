﻿namespace StatAspect.Application.MediaTracking.Commands;

/// <summary>
/// Represents a command to update a search key.
/// </summary>
public sealed class UpdateSearchKeyCommand : IRequest
{
    /// <summary>
    /// Gets the target search key identifier.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Gets the updated name of the search key.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets the updated description of the search key.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Initializes a new <see cref="UpdateSearchKeyCommand"/> instance.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public UpdateSearchKeyCommand(int id, string name, string? description)
    {
        Guard.Argument(() => name).NotNull();

        Id = id;
        Name = name;
        Description = description;
    }
}