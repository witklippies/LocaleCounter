using Microsoft.AspNetCore.Mvc;

using LocaleCounter.Entities;

namespace LocaleCounter.Controllers;

[ApiController]
[Route("[controller]")]
public class MyCounterController : ControllerBase
{
    private readonly ILogger<MyCounterController> _logger;
    private readonly IMyCounter _myCounter;

    public MyCounterController(ILogger<MyCounterController> logger,
                IMyCounter myCounter)
    {
        _logger = logger;
        _myCounter = myCounter;
    }

    // [HttpGet(Name = "GetCounter")]
    [HttpGet("/count")]
    public int Get()
    {
        return _myCounter.count();
    }

    // [HttpGet(Name = "GetString")]
    [HttpGet("/value")]
    public string GetString()
    {
        return _myCounter.value();
    }
}
