﻿// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Services;
using StatAspect.Domain.MediaTracking.ValueObjects;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.OneOf.Results;
using StatAspect.SharedKernel.OneOf.Results.TargetProperties;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents an <see cref="AddSearchKeyCommand"/> handler.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class AddSearchKeyHandler : IRequestHandler<AddSearchKeyCommand, OneOf<SearchKeyId, AlreadyExists<Name>>>
{
    private readonly ISearchKeyService _searchKeyService;

    public AddSearchKeyHandler(ISearchKeyService searchKeyService)
    {
        _searchKeyService = searchKeyService;
    }

    /// <summary>
    /// Handles the <see cref="AddSearchKeyCommand"/>.
    /// <remarks>Reflection usage only.</remarks>
    /// </summary>
    public Task<OneOf<SearchKeyId, AlreadyExists<Name>>> Handle(AddSearchKeyCommand command, CancellationToken cancellationToken)
    {
        var newSearchKey = new NewSearchKey(
            new SearchKeyName(command.Name),
            command.Description is not null ? new SearchKeyDescription(command.Description) : null);

        return _searchKeyService.AddAsync(newSearchKey);
    }
}