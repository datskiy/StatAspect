﻿using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Services;
using StatAspect.SharedKernel.Results;
using StatAspect.SharedKernel.Results.Properties;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a search key update request handler.
/// <remarks>
/// <list type="bullet">
/// <item>Usable via reflection only.</item>
/// </list>
/// </remarks>
/// </summary>
public sealed class UpdateSearchKeyHandler : IRequestHandler<UpdateSearchKeyCommand, OneOf<Success, NotFound, AlreadyExists<Name>>>
{
    private readonly ISearchKeyService _searchKeyService;

    public UpdateSearchKeyHandler(ISearchKeyService searchKeyService)
    {
        _searchKeyService = searchKeyService;
    }

    /// <summary>
    /// Returns a result of processing the <see cref="UpdateSearchKeyCommand"/> request.
    /// <remarks>
    /// <list type="bullet">
    /// <item>Usable via reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<OneOf<Success, NotFound, AlreadyExists<Name>>> Handle(UpdateSearchKeyCommand request, CancellationToken cancellationToken)
    {
        Guard.Argument(() => request).NotNull();

        var modifiedSearchKey = new ModifiedSearchKey(request.Id, request.Name, request.Description);
        return _searchKeyService.UpdateAsync(modifiedSearchKey);
    }
}