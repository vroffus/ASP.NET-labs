using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CalcController : ControllerBase
{
    private readonly CalcService _calcService;

    public CalcController(CalcService calcService)
    {
        _calcService = calcService;
    }

    [HttpGet("add/{a}/{b}")]
    public IActionResult Add(int a, int b)
    {
        var result = _calcService.Add(a, b);
        return Ok(result);
    }

    [HttpGet("subtract/{a}/{b}")]
    public IActionResult Subtract(int a, int b)
    {
        var result = _calcService.Subtract(a, b);
        return Ok(result);
    }

    [HttpGet("multiply/{a}/{b}")]
    public IActionResult Multiply(int a, int b)
    {
        var result = _calcService.Multiply(a, b);
        return Ok(result);
    }

    [HttpGet("divide/{a}/{b}")]
    public IActionResult Divide(int a, int b)
    {
        try
        {
            var result = _calcService.Divide(a, b);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
