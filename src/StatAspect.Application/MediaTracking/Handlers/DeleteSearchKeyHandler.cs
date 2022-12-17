using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain.MediaTracking.Identifiers;
using StatAspect.Domain.MediaTracking.Services;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a search key deletion request handler.
/// <remarks>
/// <list type="bullet">
/// <item>Usable via reflection only.</item>
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
    /// <item>Usable via reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    public Task<OneOf<Success, NotFound>> Handle(DeleteSearchKeyCommand request, CancellationToken cancellationToken)
    {
        var searchKeyId = new SearchKeyId(request.Id);
        return _searchKeyService.DeleteAsync(searchKeyId);
    }
}