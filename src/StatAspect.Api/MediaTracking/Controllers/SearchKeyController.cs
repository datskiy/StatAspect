// ReSharper disable UnusedParameter.Local
// ReSharper disable ConvertClosureToMethodGroup

using StatAspect.Api._Common.Controllers.Abstractions;
using StatAspect.Api.MediaTracking.Mappers;
using StatAspect.Api.MediaTracking.Models.Requests;
using StatAspect.Api.MediaTracking.Models.Responses;
using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Application.MediaTracking.Queries;

namespace StatAspect.Api.MediaTracking.Controllers;

/// <summary>
/// Represents a search key controller.
/// </summary>
[Route("media-tracking/search-keys")]
[ApiExplorerSettings(GroupName = "Search keys")]
public sealed class SearchKeyController : BaseApiController
{
    private readonly IMediator _mediator;

    public SearchKeyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Returns a specified search key.
    /// </summary>
    /// <param name="id">The identifier of a search key.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    /// <response code="200">The search key was found.</response>
    /// <response code="400">The request was invalid.</response>
    /// <response code="404">The search key was not found.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(SearchKeyResponseBody), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
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
    /// <param name="offset">The number of entries to skip.</param>
    /// <param name="limit">The maximum number of entries to take.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    /// <response code="200">The search key sequence was filtered.</response>
    /// <response code="400">The request was invalid.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SearchKeyResponseBody>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllAsync(
        [FromQuery] int offset = 0,
        [FromQuery] int limit = int.MaxValue,
        CancellationToken cancellationToken = default)
    {
        var query = new GetSearchKeysQuery(offset, limit);
        var searchKeys = await _mediator.Send(query, cancellationToken);

        return Ok(searchKeys.MapToResponseBody());
    }

    /// <summary>
    /// Adds a new search key.
    /// </summary>
    /// <param name="request">A new search key.</param>
    /// <response code="201">The search key was successfully added.</response>
    /// <response code="400">The request was invalid.</response>
    /// <response code="409">The search key with the same name already exists.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
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
    /// <param name="id">The identifier of a search key.</param>
    /// <param name="request">A modified search key.</param>
    /// <response code="200">The search key was successfully updated.</response>
    /// <response code="400">The request was invalid.</response>
    /// <response code="404">The search key was not found.</response>
    /// <response code="409">The search key with the same name already exists.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
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
    /// <param name="id">The identifier of a search key.</param>
    /// <response code="200">The search key was successfully deleted.</response>
    /// <response code="400">The request was invalid.</response>
    /// <response code="404">The search key was not found.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var command = new DeleteSearchKeyCommand(id);
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            success => Ok(),
            notFound => NotFound());
    }
}