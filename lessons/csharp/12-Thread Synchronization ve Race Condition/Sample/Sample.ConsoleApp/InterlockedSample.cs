namespace Sample.ConsoleApp;

public static class InterlockedSample
{
    public static void Do()
    {
        var number = 0;
        var interlockedNumber = 0;

        ThreadStart work = () =>
        {
            for (var i = 0; i < 1_000_000; i++)
            {
                number++;

                //Atomic operation
                //Decrement, Add, Exchange
                Interlocked.Increment(ref interlockedNumber);
            }
        };

        var threads = new Thread[Environment.ProcessorCount];
        for (var i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(work);
            threads[i].Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine($"Number: {number} InterlockedNumber: {interlockedNumber}");
    }
}