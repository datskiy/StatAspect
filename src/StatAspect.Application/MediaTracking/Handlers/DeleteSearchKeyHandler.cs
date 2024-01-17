// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain.MediaTracking.Services;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.OneOf.Results;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a <see cref="DeleteSearchKeyCommand"/> handler.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class DeleteSearchKeyHandler : IRequestHandler<DeleteSearchKeyCommand, OneOf<Success, NotFound>>
{
    private readonly ISearchKeyService _searchKeyService;

    public DeleteSearchKeyHandler(ISearchKeyService searchKeyService)
    {
        _searchKeyService = searchKeyService;
    }

    /// <summary>
    /// Handles the <see cref="DeleteSearchKeyCommand"/>.
    /// <remarks>Reflection usage only.</remarks>
    /// </summary>
    public Task<OneOf<Success, NotFound>> Handle(DeleteSearchKeyCommand command, CancellationToken cancellationToken)
    {
        var targetSearchKeyId = new SearchKeyId(command.Id);
        return _searchKeyService.DeleteAsync(targetSearchKeyId);
    }
}