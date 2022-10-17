using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Sample.Api.Controllers;

[Route("api/sample")]
[ApiController]
public class SampleController : ControllerBase
{
    private readonly ILogger<SampleController> _logger;
    private readonly Serilog.ILogger _logger2;

    public SampleController(
        ILogger<SampleController> logger,
        Serilog.ILogger logger2)
    {
        _logger = logger;
        _logger2 = logger2;
        //_logger2 = logger2.ForContext<SampleController>();
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

    [HttpGet("add-with-serilog/{n1}/{n2}")]
    public int AddWithSerilog(int n1, int n2)
    {
        int result = n1 + n2;

        _logger2.Verbose("Sayı1: {Number1}, Sayı2: {Number2}, Sonuç: {Result}", n1, n2, result);
        _logger2.Debug("Sayı1: {Number1}, Sayı2: {Number2}, Sonuç: {Result}", n1, n2, result);
        _logger2.Information("Sayı1: {Number1}, Sayı2: {Number2}, Sonuç: {Result}", n1, n2, result);
        _logger2.Warning("Sayı1: {Number1}, Sayı2: {Number2}, Sonuç: {Result}", n1, n2, result);
        _logger2.Error("Sayı1: {Number1}, Sayı2: {Number2}, Sonuç: {Result}", n1, n2, result);
        _logger2.Fatal("Sayı1: {Number1}, Sayı2: {Number2}, Sonuç: {Result}", n1, n2, result);

        var model = new SampleModel("Ahmet Faruk", "ULU");
        Log.ForContext<SampleController>().Write(Serilog.Events.LogEventLevel.Warning, "Log with static {@person}", model);

        return result;
    }
}

public class SampleModel
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public SampleModel(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }
}
