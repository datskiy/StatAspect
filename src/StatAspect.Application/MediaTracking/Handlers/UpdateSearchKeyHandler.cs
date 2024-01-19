// ReSharper disable UnusedType.Global

using StatAspect.Application._Common.Pipelines.Responses;
using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain.MediaTracking.Aggregates;
using StatAspect.Domain.MediaTracking.Services;
using StatAspect.Domain.MediaTracking.ValueObjects;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.OneOf.Results;
using StatAspect.SharedKernel.OneOf.Results.TargetProperties;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents an <see cref="UpdateSearchKeyCommand"/> handler.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class UpdateSearchKeyHandler : IRequestHandler<UpdateSearchKeyCommand, PipelineResponse<OneOf<Success, NotFound, AlreadyExists<Name>>>>
{
    private readonly ISearchKeyService _searchKeyService;

    public UpdateSearchKeyHandler(ISearchKeyService searchKeyService)
    {
        _searchKeyService = searchKeyService;
    }

    /// <summary>
    /// Handles the <see cref="UpdateSearchKeyCommand"/>.
    /// <remarks>Reflection usage only.</remarks>
    /// </summary>
    public async Task<PipelineResponse<OneOf<Success, NotFound, AlreadyExists<Name>>>> Handle(UpdateSearchKeyCommand command, CancellationToken cancellationToken)
    {
        var modifiedSearchKey = BuildModifiedSearchKey(command);
        var result = await _searchKeyService.UpdateAsync(modifiedSearchKey);

        return new PipelineResponse<OneOf<Success, NotFound, AlreadyExists<Name>>>(result);
    }

    private static ModifiedSearchKey BuildModifiedSearchKey(UpdateSearchKeyCommand command)
    {
        return new ModifiedSearchKey(
            new SearchKeyId(command.Id),
            new SearchKeyName(command.Name),
            command.Description is not null
                ? new SearchKeyDescription(command.Description)
                : null);
    }
}