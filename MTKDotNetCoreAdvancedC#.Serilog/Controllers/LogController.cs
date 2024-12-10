namespace MTKDotNetCoreAdvancedC_.Serilog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LogController : ControllerBase
{
    ILogger<LogController> _logger;

    public LogController(ILogger<LogController> logger)
    {
        _logger = logger;
    }

    #region Test

    [HttpGet]
    public IActionResult Test()
    {
        _logger.LogInformation("Hello!");
        return Ok();
    }

    #endregion

}
