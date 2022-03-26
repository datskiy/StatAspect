using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain.MediaTracking.Services;
using StatAspect.Domain.MediaTracking.ValueObjects;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a search key update request handler.
/// </summary>
public sealed class UpdateSearchKeyHandler : IRequestHandler<UpdateSearchKeyCommand, OneOf<Success, NotFound, AlreadyExists>>
{
    private readonly ISearchKeyService _searchKeyService;

    public UpdateSearchKeyHandler(ISearchKeyService searchKeyService)
    {
        _searchKeyService = searchKeyService;
    }

    /// <summary>
    /// Returns a result of processing the <see cref="UpdateSearchKeyCommand"/> request.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<OneOf<Success, NotFound, AlreadyExists>> Handle(UpdateSearchKeyCommand request, CancellationToken cancellationToken)
    {
        Guard.Argument(() => request).NotNull();

        var modifiedSearchKey = new ModifiedSearchKey(request.Id, request.Name, request.Description);
        return _searchKeyService.UpdateAsync(modifiedSearchKey);
    }
}