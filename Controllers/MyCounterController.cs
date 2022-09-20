using Microsoft.AspNetCore.Mvc;

using LocaleCounter.Entities;

namespace LocaleCounter.Controllers;

[ApiController]
[Route("[controller]")]
public class MyCounterController : ControllerBase
{
    private readonly ILogger<MyCounterController> _logger;
    private readonly IMyCounter _myCounter;
    private readonly INumberToWords _numberToWords;

    public MyCounterController(ILogger<MyCounterController> logger,
                IMyCounter myCounter,
                INumberToWords numberToWords)
    {
        _logger = logger;
        _myCounter = myCounter;
        _numberToWords = numberToWords;
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
        var ISL = new MyStringLocalizer();

        var value = _numberToWords.Convert(_myCounter.value());

        //return ISL[value] + "\n";
        return value + "\n";
    }
}
