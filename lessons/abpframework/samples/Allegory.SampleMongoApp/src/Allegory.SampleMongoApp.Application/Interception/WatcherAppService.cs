﻿using System;
using System.Threading.Tasks;

namespace Allegory.SampleMongoApp.Interception;

[Watcher(2)]
public class WatcherAppService : SampleMongoAppAppService, IWatcherAppService
{
    public virtual async Task<int> Method1Async()
    {
        var duration = Random.Shared.Next(1800, 2200);
        await Task.Delay(duration);
        return duration;
    }

    [Watcher(1)]
    public virtual async Task<int> Method2Async()
    {
        var duration = Random.Shared.Next(800, 1200);
        await Task.Delay(duration);
        return duration;
    }

    [Watcher(IsDisabled = true)]
    public virtual async Task Method3Async()
    {
        await Task.Delay(Random.Shared.Next(2500, 3000));
    }

    [Watcher(1)]
    public async Task Method4Async()
    {
        //virtual olmadığı için sadece interfaceler interception yapabilir!!!
        await Task.Delay(Random.Shared.Next(1000, 1500));
    }
}