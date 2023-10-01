// ReSharper disable UnusedParameter.Local
// ReSharper disable ConvertClosureToMethodGroup

using StatAspect.Api._Common.Controllers.Abstractions;
using StatAspect.Api.MediaTracking.Mappers;
using StatAspect.Api.MediaTracking.Models.Requests;
using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Application.MediaTracking.Queries;

namespace StatAspect.Api.MediaTracking.Controllers;

/// <summary>
/// Represents a search key controller.
/// </summary>
[Route("media-tracking/search-keys")]
public sealed class SearchKeyController : BaseController
{
    private readonly IMediator _mediator;

    public SearchKeyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Returns a specified search key.
    /// </summary>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var query = new GetSearchKeyQuery(id);
        var searchKey = await _mediator.Send(query, cancellationToken);

        return searchKey is not null
            ? Ok(searchKey.MapToResponseBody())
            : NotFound();
    }

    /// <summary>
    /// Returns a sequence of search keys filtered according to the specified parameters.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int offset = 0, [FromQuery] int limit = int.MaxValue,
        CancellationToken cancellationToken = default)
    {
        var query = new GetSearchKeysQuery(offset, limit);
        var searchKeys = await _mediator.Send(query, cancellationToken);

        return Ok(searchKeys.MapToResponseBody());
    }

    /// <summary>
    /// Adds a new search key.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] NewSearchKeyRequestBody request)
    {
        var command = new AddSearchKeyCommand(request.Name, request.Description);
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            addedSearchKeyId => Created<SearchKeyController>(addedSearchKeyId),
            alreadyExists => Conflict(alreadyExists));
    }

    /// <summary>
    /// Updates a search key.
    /// </summary>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] ModifiedSearchKeyRequestBody request)
    {
        var command = new UpdateSearchKeyCommand(id, request.Name, request.Description);
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            success => Ok(),
            notFound => NotFound(),
            alreadyExists => Conflict(alreadyExists));
    }

    /// <summary>
    /// Deletes a search key.
    /// </summary>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var command = new DeleteSearchKeyCommand(id);
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            success => Ok(),
            notFound => NotFound());
    }
}