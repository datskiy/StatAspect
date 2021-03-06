using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain.MediaTracking.Identifiers;
using StatAspect.Domain.MediaTracking.Services;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a search key deletion request handler.
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
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<OneOf<Success, NotFound>> Handle(DeleteSearchKeyCommand request, CancellationToken cancellationToken)
    {
        Guard.Argument(() => request).NotNull();

        var searchKeyId = new SearchKeyId(request.Id);
        return _searchKeyService.DeleteAsync(searchKeyId);
    }
}