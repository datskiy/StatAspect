using StatAspect.Api.Models.Requests.MediaTracking;
using StatAspect.Api.Models.Responses.MediaTracking;
using StatAspect.Application.Commands.MediaTracking;
using StatAspect.Application.Queries.MediaTracking;

namespace StatAspect.Api.Controllers.MediaTracking;

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
        return Created($"mediaTracking/searchKey/{searchKeyId}"/*todo: use ApiRouting.Get/{createdId}*/, new { Id = searchKeyId });
    }

    /// <summary>
    /// XXX
    /// </summary>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateSearchKeyRequest request)
    {
        await Task.Delay(0);
        return Ok();
    }

    /// <summary>
    /// XXX
    /// </summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromQuery] int id)
    {
        await Task.Delay(0);
        return NoContent();
    }
}