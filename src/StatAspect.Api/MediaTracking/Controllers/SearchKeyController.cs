using StatAspect.Api.MediaTracking.Models.Requests;
using StatAspect.Api.MediaTracking.Models.Responses;
using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Application.MediaTracking.Queries;

namespace StatAspect.Api.MediaTracking.Controllers;

/// <summary>
/// Represents a search key controller.
/// </summary>
[ApiController]
[Route("mediaTracking/[controller]")]
public sealed class SearchKeyController : ControllerBase
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
    public async Task<IActionResult> GetAsync([FromQuery] int id, CancellationToken cancellationToken)
    {
        var query = new GetSearchKeyQuery(id);
        var searchKey = await _mediator.Send(query, cancellationToken);
        return Ok(_mapper.Map<SearchKeyResponse>(searchKey));
    }

    /// <summary>
    /// Gets multiple search keys filtered by the specified paramerters.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetListAsync(CancellationToken cancellationToken) // todo: paging, filtering, sorting
    {
        var query = new GetSearchKeysQuery();
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
        var searchKeyId = await _mediator.Send(command);
        return Created($"mediaTracking/searchKey/{searchKeyId.Value}"/*todo: use ApiRouting.Get/{createdId}*/, new { Id = searchKeyId.Value });
    }

    /// <summary>
    /// Updates a search key.
    /// </summary>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync([FromQuery] int id, [FromBody] UpdateSearchKeyRequest request)
    {
        var command = new UpdateSearchKeyCommand(id, request.Name, request.Description);
        await _mediator.Send(command);
        return Ok();
    }

    /// <summary>
    /// Deletes a search key.
    /// </summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromQuery] int id)
    {
        var command = new DeleteSearchKeyCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}