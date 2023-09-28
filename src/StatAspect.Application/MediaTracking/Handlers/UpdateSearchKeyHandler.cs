// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Services;
using StatAspect.Domain.MediaTracking.ValueObjects;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.Results;
using StatAspect.SharedKernel.Results.TargetProperties;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents an <see cref="UpdateSearchKeyCommand"/> handler.
/// <remarks>Used only through reflection.</remarks>
/// </summary>
public sealed class UpdateSearchKeyHandler : IRequestHandler<UpdateSearchKeyCommand, OneOf<Success, NotFound, AlreadyExists<Name>>>
{
    private readonly ISearchKeyService _searchKeyService;

    public UpdateSearchKeyHandler(ISearchKeyService searchKeyService)
    {
        _searchKeyService = searchKeyService;
    }

    /// <summary>
    /// Handles the <see cref="UpdateSearchKeyCommand"/> request.
    /// <remarks>Used only through reflection.</remarks>
    /// </summary>
    public Task<OneOf<Success, NotFound, AlreadyExists<Name>>> Handle(UpdateSearchKeyCommand command, CancellationToken cancellationToken)
    {
        var modifiedSearchKey = new ModifiedSearchKey(
            new SearchKeyId(command.Id),
            new SearchKeyName(command.Name),
            command.Description is not null ? new SearchKeyDescription(command.Description) : null);

        return _searchKeyService.UpdateAsync(modifiedSearchKey);
    }
}