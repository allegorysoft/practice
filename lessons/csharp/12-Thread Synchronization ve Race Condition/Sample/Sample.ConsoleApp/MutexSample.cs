using System.Diagnostics;

namespace Sample.ConsoleApp;

public static class MutexSample
{
    public static async Task Do()
    {
        //SingleProcess();
        //MultiProcess();
        await AsyncMutex();
    }

    private static void SingleProcess()
    {
        using var mutex = new Mutex();
        var threads = new Thread[5];

        ThreadStart work = () =>
        {
            Console.WriteLine($"1.part Thread: {Environment.CurrentManagedThreadId}");
            try
            {
                //Critical section
                mutex.WaitOne();
                Console.WriteLine($"2.part Thread: {Environment.CurrentManagedThreadId}");
                //await Task.Delay(2000); !!!
                Thread.Sleep(2000);
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        };

        for (var i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(work);
            threads[i].Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }
    }

    private static void MultiProcess()
    {
        using var mutex = new Mutex(false, "App1/MultiProcess");
        for (var i = 0; i < 20; i++)
        {
            try
            {
                //Critical section
                mutex.WaitOne();
                //await Task.Delay(3000); !!!
                Console.WriteLine(
                    $"Process: {Environment.ProcessId} Thread: {Environment.CurrentManagedThreadId} {DateTime.Now}");
                Thread.Sleep(3000);
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }

    private static async Task AsyncMutex()
    {
        using var mutex = await TryAcquireAsync();
        Console.WriteLine(
            $"Enter Process: {Environment.ProcessId} Thread: {Environment.CurrentManagedThreadId} {DateTime.Now}");
        await Task.Delay(5000);
        Console.WriteLine(
            $"Exit Process: {Environment.ProcessId} Thread: {Environment.CurrentManagedThreadId} {DateTime.Now}");
    }

    private static async Task<Mutex> TryAcquireAsync()
    {
        tryAgain:
        var mutex = new Mutex(false, "App1/AsyncMutex", out var owned);
        if (!owned)
        {
            mutex.Dispose();
            await Task.Delay(1000);
            goto tryAgain;
        }

        return mutex;
    }
}