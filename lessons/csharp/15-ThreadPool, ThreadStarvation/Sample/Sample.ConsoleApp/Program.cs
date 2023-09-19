//ThreadPoolSample();
//IocpThreadSample();
ThreadStarvationSample();

Console.ReadLine();
return;

void ThreadPoolSample()
{
    for (var i = 0; i < 50; i++)
    {
        ThreadPool.QueueUserWorkItem(s => { Thread.Sleep(10_000); });
    }

    for (var i = 0; i < 100; i++)
    {
        Console.WriteLine("CompletedWorkItem: {0}, PendingWorkItem: {1}, ThreadCount: {2}",
            ThreadPool.CompletedWorkItemCount,
            ThreadPool.PendingWorkItemCount,
            ThreadPool.ThreadCount);

        Thread.Sleep(1000);
    }

    ThreadPool.GetMinThreads(out var minWorkerThreads, out var minCompletionPortThreads);
    ThreadPool.GetAvailableThreads(out var availableWorkerThreads, out var availableCompletionPortThreads);
    ThreadPool.GetMaxThreads(out var maxWorkerThreads, out var maxCompletionPortThreads);

    ThreadPool.SetMinThreads(1, 1);
    ThreadPool.SetMaxThreads(100, 10);
}

void IocpThreadSample()
{
    for (var i = 0; i < 10; i++)
    {
        _ = Task.Run(async () =>
        {
            await new HttpClient().GetAsync("https://www.google.com");
            Console.WriteLine("Done");
            Console.ReadLine();
        });
    }

    while (true)
    {
        ThreadPool.GetAvailableThreads(out var workerThreads, out var iocpThreads);
        Console.WriteLine("Worker threads: {0} IOCP threads: {1} ThreadCount: {2}", workerThreads, iocpThreads,
            ThreadPool.ThreadCount);
        Thread.Sleep(1000);
    }
}

void ThreadStarvationSample()
{
    var isSetMinThreads = ThreadPool.SetMinThreads(1, 1);
    var isSetMaxThreads = ThreadPool.SetMaxThreads(5, 1);
    var semaphore = new SemaphoreSlim(1);
    var subWork = async (int number) =>
    {
        Console.WriteLine("Number: {0}, ThreadId: {1} started", number, Environment.CurrentManagedThreadId);
        await Task.Delay(1000);
        Console.WriteLine("End: {0}, ThreadId: {1} started", number, Environment.CurrentManagedThreadId);
    };

    for (var i = 0; i < 4; i++)
    {
        ThreadPool.QueueUserWorkItem(number =>
        {
            semaphore.Wait();
            subWork((int)number!).GetAwaiter().GetResult();
            semaphore.Release();
        }, i);
    }
}