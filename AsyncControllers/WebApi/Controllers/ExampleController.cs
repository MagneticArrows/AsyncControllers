using AsyncControllers.Attributes;
using Microsoft.AspNetCore.Mvc;
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
}