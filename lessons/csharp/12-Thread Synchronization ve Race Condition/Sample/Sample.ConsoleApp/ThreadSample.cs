namespace Sample.ConsoleApp;

public class ThreadSample
{
    [ThreadStatic] private static int _threadStaticNumber = 0;
    private static int _number = 0;

    public static void Do()
    {
        //ThreadStaticSample();
        ThreadLocalSample();
    }

    private static void ThreadStaticSample()
    {
        var threads = new Thread[5];
        var lockObject = new object();

        ThreadStart work = () =>
        {
            lock (lockObject)
            {
                for (var i = 0; i < 100; i++)
                {
                    _number++;
                    _threadStaticNumber++;
                }
            }

            Console.WriteLine($"Number: {_number} ThreadStatic: {_threadStaticNumber}");
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

    private static void ThreadLocalSample()
    {
        using var threadLocal = new ThreadLocal<int>();
        var threads = new Thread[5];
        var number = 0;
        var lockObject = new object();

        ThreadStart work = () =>
        {
            lock (lockObject)
            {
                for (var i = 0; i < 100; i++)
                {
                    number++;
                    threadLocal.Value++;
                }
            }

            Console.WriteLine($"Number: {number} ThreadLocal: {threadLocal.Value}");
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
}