

namespace CosmosDB_Demo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly ICosmosDbService _cosmosDbService;
    public ItemsController(ICosmosDbService cosmosDbService)
    {
        _cosmosDbService = cosmosDbService ?? throw new ArgumentNullException(nameof(cosmosDbService));
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        return Ok(await _cosmosDbService.GetMultipleAsync("SELECT * FROM c"));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        return Ok(await _cosmosDbService.GetAsync(id));
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SampleData item)
    {
        item.Id = Guid.NewGuid().ToString();
        await _cosmosDbService.AddAsync(item);
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Edit([FromBody] SampleData item)
    {
        await _cosmosDbService.UpdateAsync(item.Id, item);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _cosmosDbService.DeleteAsync(id);
        return NoContent();
    }
}
