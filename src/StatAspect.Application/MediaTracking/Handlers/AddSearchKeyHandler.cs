using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Services;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.Results;
using StatAspect.SharedKernel.Results.Properties;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a new search key addition request handler.
/// <remarks>
/// <list type="bullet">
/// <item>Usable via reflection only.</item>
/// </list>
/// </remarks>
/// </summary>
public sealed class AddSearchKeyHandler : IRequestHandler<AddSearchKeyCommand, OneOf<SearchKeyId, AlreadyExists<Name>>>
{
    private readonly ISearchKeyService _searchKeyService;

    public AddSearchKeyHandler(ISearchKeyService searchKeyService)
    {
        _searchKeyService = searchKeyService;
    }

    /// <summary>
    /// Returns a result of processing the <see cref="AddSearchKeyCommand"/> request.
    /// <remarks>
    /// <list type="bullet">
    /// <item>Usable via reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<OneOf<SearchKeyId, AlreadyExists<Name>>> Handle(AddSearchKeyCommand request, CancellationToken cancellationToken)
    {
        Guard.Argument(() => request).NotNull();

        var newSearchKey = new NewSearchKey(request.Name, request.Description);
        return _searchKeyService.AddAsync(newSearchKey);
    }
}