using System.Diagnostics;

namespace Sample.ConsoleApp;

public static class MutexSample
{
    public static async Task Do()
    {
        //SingleProcess();
        //await MultiProcess();
        await AsyncMutex();
    }

    private static void SingleProcess()
    {
        var mutex = new Mutex(); //using !!!
        for (var i = 0; i < 5; i++)
        {
            new Thread(() =>
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
            }).Start();
        }
    }

    private static async Task MultiProcess()
    {
        using var mutex = new Mutex(false, "App1/MultiProcess");
        for (var i = 0; i < 20; i++)
        {
            await Task.Delay(3000);
            try
            {
                //Critical section
                mutex.WaitOne();
                //await Task.Delay(3000); !!!
                Console.WriteLine(
                    $"Process: {Environment.ProcessId} Thread: {Environment.CurrentManagedThreadId}");
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
            $"Enter Process: {Environment.ProcessId} Thread: {Environment.CurrentManagedThreadId}");
        await Task.Delay(5000);
        Console.WriteLine(
            $"Exit Process: {Environment.ProcessId} Thread: {Environment.CurrentManagedThreadId}");
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