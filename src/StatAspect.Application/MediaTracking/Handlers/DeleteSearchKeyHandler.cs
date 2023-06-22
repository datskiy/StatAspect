// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain.MediaTracking.Services;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a search key deletion request handler.
/// <remarks>
/// <list type="bullet">
/// <item>Reflection only.</item>
/// </list>
/// </remarks>
/// </summary>
public sealed class DeleteSearchKeyHandler : IRequestHandler<DeleteSearchKeyCommand, OneOf<Success, NotFound>>
{
    private readonly ISearchKeyService _searchKeyService;

    public DeleteSearchKeyHandler(ISearchKeyService searchKeyService)
    {
        _searchKeyService = searchKeyService;
    }

    /// <summary>
    /// Returns a result of processing the <see cref="DeleteSearchKeyCommand"/> request.
    /// <remarks>
    /// <list type="bullet">
    /// <item>Reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<OneOf<Success, NotFound>> Handle(DeleteSearchKeyCommand command, CancellationToken cancellationToken)
    {
        Guard.Argument(() => command).NotNull();

        var searchKeyId = new SearchKeyId(command.Id);
        return _searchKeyService.DeleteAsync(searchKeyId);
    }
}