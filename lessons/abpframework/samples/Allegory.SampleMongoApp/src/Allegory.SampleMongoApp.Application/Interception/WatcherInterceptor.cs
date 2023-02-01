using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;
using Volo.Abp.DynamicProxy;

namespace Allegory.SampleMongoApp.Interception;

public class WatcherInterceptor : AbpInterceptor, ITransientDependency
{
    private readonly ILogger<WatcherInterceptor> _logger;

    public WatcherInterceptor(ILogger<WatcherInterceptor> logger)
    {
        _logger = logger;
    }

    public override async Task InterceptAsync(IAbpMethodInvocation invocation)
    {
        if (!WatcherHelper.IsWatcherMethod(invocation.Method, out var watcherAttribute))
        {
            await invocation.ProceedAsync();
            return;
        }

        var startTime = Stopwatch.GetTimestamp();
        await invocation.ProceedAsync();
        var diff = Stopwatch.GetElapsedTime(startTime);

        if (diff > watcherAttribute.Timeout)
        {
            _logger.LogWarning(
                "{Method} metodu çalışma süresi beklenilenden uzun sürdü. Beklenen süre: {Expected}, Geçen süre: {Real}",
                invocation.Method.DeclaringType?.FullName + "." + invocation.Method.Name,
                watcherAttribute.Timeout,
                diff);
        }
    }
}