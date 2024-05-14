using AsyncControllers.Attributes;
using AsyncControllers.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController(ILogger<ExampleController> _logger, IExampleService _exampleService) : ControllerBase
{
    [HttpAsyncPost("runExample")]
    public async Task<ActionResult> RunExample()
    {
        var res = await _exampleService.RunExample();
        return Ok(res);
    }


    [HttpGet]
    [Route("api/test/sync")]
    [Asyncify]
    public IActionResult SyncAction()
    {
        // Simulate some work
        Thread.Sleep(5000); // 5 seconds delay
        return Ok("Sync action completed");
    }
}