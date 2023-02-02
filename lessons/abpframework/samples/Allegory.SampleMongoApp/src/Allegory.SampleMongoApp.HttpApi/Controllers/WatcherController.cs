using System.Threading.Tasks;
using Allegory.SampleMongoApp.Interception;
using Microsoft.AspNetCore.Mvc;

namespace Allegory.SampleMongoApp.Controllers;

[Route("api/app/watcher-service")]
public class WatcherController : SampleMongoAppController
{
    protected IWatcherAppService WatcherAppService { get; }

    public WatcherController(IWatcherAppService watcherAppService)
    {
        WatcherAppService = watcherAppService;
    }

    [HttpPost("method4")]
    public Task Method4Async()
    {
        return WatcherAppService.Method4Async();
    }
}