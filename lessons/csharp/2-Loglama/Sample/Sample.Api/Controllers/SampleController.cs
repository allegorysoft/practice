using Microsoft.AspNetCore.Mvc;

namespace Sample.Api.Controllers;

[Route("api/sample")]
[ApiController]
public class SampleController : ControllerBase
{
    private readonly ILogger<SampleController> _logger;

    public SampleController(ILogger<SampleController> logger)
    {
        _logger = logger;
    }

    [HttpGet("add/{n1}/{n2}")]
    public int Add(int n1, int n2)
    {
        int result = n1 + n2;

        _logger.LogTrace("Sayı1: {Number1}, Sayı2: {Number2}, Sonuç: {Result}", n1, n2, result);
        _logger.LogDebug("Sayı1: {Number1}, Sayı2: {Number2}, Sonuç: {Result}", n1, n2, result);
        _logger.LogInformation("Sayı1: {Number1}, Sayı2: {Number2}, Sonuç: {Result}", n1, n2, result);
        _logger.LogWarning("Sayı1: {Number1}, Sayı2: {Number2}, Sonuç: {Result}", n1, n2, result);
        _logger.LogError("Sayı1: {Number1}, Sayı2: {Number2}, Sonuç: {Result}", n1, n2, result);
        _logger.LogCritical("Sayı1: {Number1}, Sayı2: {Number2}, Sonuç: {Result}", n1, n2, result);
        _logger.Log(LogLevel.None, "Sayı1: {Number1}, Sayı2: {Number2}, Sonuç: {Result}", n1, n2, result);

        return result;
    }
}
