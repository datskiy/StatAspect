using StatAspect.Api.Models.Requests.MediaTracking;
using StatAspect.Api.Models.Responses.MediaTracking;
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
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(_mapper.Map<SearchKeyResponse>(result));
    }

    /// <summary>
    /// Gets multiple search keys filtered by the specified paramerters.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetListAsync(CancellationToken cancellationToken) // todo: paging, filtering, sorting
    {
        var query = new GetSearchKeysQuery();
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(_mapper.Map<IEnumerable<SearchKeyResponse>>(result));
    }

    /// <summary>
    /// XXX
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddSearchKeyRequest request)
    {
        await Task.Delay(0);
        return Created("searchKey", null);
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