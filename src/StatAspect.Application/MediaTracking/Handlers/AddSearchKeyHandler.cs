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
/// Represents a search key addition request handler.
/// <remarks>Reflection only.</remarks>
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
    /// <remarks>Reflection only.</remarks>
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<OneOf<SearchKeyId, AlreadyExists<Name>>> Handle(AddSearchKeyCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var newSearchKey = new NewSearchKey(
            new SearchKeyName(command.Name),
            command.Description is not null ? new SearchKeyDescription(command.Description) : null); // TODO: method

        return _searchKeyService.AddAsync(newSearchKey);
    }
}