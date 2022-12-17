using StatAspect.Api.General.Controllers;
using StatAspect.Api.MediaTracking.Models.Requests;
using StatAspect.Api.MediaTracking.Models.Responses;
using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Application.MediaTracking.Queries;

namespace StatAspect.Api.MediaTracking.Controllers;

/// <summary>
/// Represents a search key controller.
/// </summary>
[Route("mediaTracking/searchKey")]
public sealed class SearchKeyController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SearchKeyController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets a specific search key.
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAsync([FromRoute] int id, CancellationToken cancellationToken = default)
    {
        var query = new GetSearchKeyQuery(id);
        var searchKey = await _mediator.Send(query, cancellationToken);
        return searchKey is not null
            ? Ok(_mapper.Map<SearchKeyResponse>(searchKey))
            : NotFound();
    }

    /// <summary>
    /// Gets search key collection filtered by the specified paramerters.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetListAsync([FromQuery] int offset = 0, [FromQuery] int limit = int.MaxValue, CancellationToken cancellationToken = default)
    {
        var query = new GetSearchKeysQuery(offset, limit);
        var searchKeys = await _mediator.Send(query, cancellationToken);
        return Ok(_mapper.Map<IEnumerable<SearchKeyResponse>>(searchKeys));
    }

    /// <summary>
    /// Adds a new search key.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddSearchKeyRequest request)
    {
        var command = new AddSearchKeyCommand(request.Name, request.Description);
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            addedSearchKeyId => Created($"mediaTracking/searchKey/{addedSearchKeyId.Value}", default), // TODO: come up with smth
            alreadyExists => Conflict(alreadyExists));
    }

    /// <summary>
    /// Updates a search key.
    /// </summary>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateSearchKeyRequest request)
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
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var command = new DeleteSearchKeyCommand(id);
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            success => Ok(),
            notFound => NotFound());
    }
}