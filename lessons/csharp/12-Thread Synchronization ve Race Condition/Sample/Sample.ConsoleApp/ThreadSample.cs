namespace Sample.ConsoleApp;

public class ThreadSample
{
    [ThreadStatic] private static int _threadNumber = 0;

    public static void Do()
    {
        ThreadLocalSample();
        //ThreadStaticSample();
    }

    private static void ThreadLocalSample()
    {
        var threadLocal = new ThreadLocal<int>();
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

        threadLocal.Dispose();
    }

    private static void ThreadStaticSample()
    {
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
                    _threadNumber++;
                }
            }

            Console.WriteLine($"Number: {number} ThreadLocal: {_threadNumber}");
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