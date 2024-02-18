using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TimeController : ControllerBase
{
    private readonly TimeOfDayService _timeOfDayService;

    public TimeController(TimeOfDayService timeOfDayService)
    {
        _timeOfDayService = timeOfDayService;
    }

    [HttpGet]
    public IActionResult GetTimeOfDay()
    {
        var timeOfDay = _timeOfDayService.GetTimeOfDay();
        return Ok(timeOfDay);
    }
}
