namespace Sample.ConsoleApp;

public static class SemaphoreSample
{
    public static async Task Do()
    {
        //await WithSemaphoreSlim();
        //await MaxCountParameter();
        await WithSemaphore();
    }

    private static async Task WithSemaphoreSlim()
    {
        var semaphoreSlim = new SemaphoreSlim(1); //using !!!
        var work = async () =>
        {
            try
            {
                Console.WriteLine($"1.part Thread: {Environment.CurrentManagedThreadId}");
                //Critical section
                await semaphoreSlim.WaitAsync();
                Console.WriteLine($"2.part Thread: {Environment.CurrentManagedThreadId}");
                await Task.Delay(2000);
            }
            finally
            {
                semaphoreSlim.Release();
            }
        };

        var tasks = new List<Task>();
        for (var i = 0; i < 5; i++)
        {
            tasks.Add(work());
        }

        await Task.WhenAll(tasks);
        semaphoreSlim.Dispose();
    }

    private static async Task MaxCountParameter()
    {
        using var semaphoreSlim = new SemaphoreSlim(0, 3);

        Console.WriteLine($"CurrentCount: {semaphoreSlim.CurrentCount}");
        semaphoreSlim.Release(2);
        semaphoreSlim.Release();
        //semaphoreSlim.Release(); throws exception
        Console.WriteLine($"CurrentCount: {semaphoreSlim.CurrentCount}");

        await semaphoreSlim.WaitAsync();
        await semaphoreSlim.WaitAsync();
        Console.WriteLine($"CurrentCount: {semaphoreSlim.CurrentCount}");

        await semaphoreSlim.WaitAsync();
        Console.WriteLine($"CurrentCount: {semaphoreSlim.CurrentCount}");

        await semaphoreSlim.WaitAsync();
        Console.WriteLine("Blocked");
    }

    private static async Task WithSemaphore()
    {
        using var semaphore = new Semaphore(2, 2, "App/WithSemaphore");
        try
        {
            semaphore.WaitOne();
            Console.WriteLine(
                $"Enter Process: {Environment.ProcessId} Thread: {Environment.CurrentManagedThreadId}");
            await Task.Delay(10000);
            Console.WriteLine(
                $"Exit Process: {Environment.ProcessId} Thread: {Environment.CurrentManagedThreadId}");
        }
        finally
        {
            semaphore.Release();
        }
    }
}