// ReSharper disable UnusedType.Global

using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Services;
using StatAspect.SharedKernel.Results;
using StatAspect.SharedKernel.Results.TargetProperties;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a search key update request handler.
/// <remarks>
/// <list type="bullet">
/// <item>Reflection only.</item>
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
    /// <item>Reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<OneOf<Success, NotFound, AlreadyExists<Name>>> Handle(UpdateSearchKeyCommand command, CancellationToken cancellationToken)
    {
        Guard.Argument(() => command).NotNull();

        var modifiedSearchKey = new ModifiedSearchKey(command.Id, command.Name, command.Description);
        return _searchKeyService.UpdateAsync(modifiedSearchKey);
    }
}