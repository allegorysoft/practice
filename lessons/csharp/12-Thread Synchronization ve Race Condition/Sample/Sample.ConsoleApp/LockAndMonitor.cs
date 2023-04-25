namespace Sample.ConsoleApp;

public static class LockAndMonitor
{
    private static int _money = 100;
    private static readonly object LockObject = new object();

    public static void Do()
    {
        //WithLock();
        //WithMonitor();
        DoubleCheckedLocking();
    }

    private static void WithLock()
    {
        var t1 = new Thread(() => TryPaymentWithLock(75));
        var t2 = new Thread(() => TryPaymentWithLock(75));

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine(_money);
    }

    private static void TryPaymentWithLock(int expense)
    {
        lock (LockObject)
        {
            //Critical section
            if (_money >= expense)
            {
                //await Task.Delay(1000); !!!
                Thread.Sleep(1000);
                _money -= expense;
            }
            else
            {
                Console.WriteLine("Expense payment denied.");
            }
        }
    }

    private static void WithMonitor()
    {
        var t1 = new Thread(() => TryPaymentWithMonitor(75));
        var t2 = new Thread(() => TryPaymentWithMonitor(75));

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine(_money);
    }

    private static void TryPaymentWithMonitor(int expense)
    {
        var lockTaken = false;
        try
        {
            //Critical section
            Monitor.Enter(LockObject, ref lockTaken);
            if (_money >= expense)
            {
                //await Task.Delay(1000); !!!
                Thread.Sleep(1000);
                _money -= expense;
            }
            else
            {
                Console.WriteLine("Expense payment denied.");
            }
        }
        finally
        {
            if (lockTaken)
                Monitor.Exit(LockObject);
        }
    }

    private static void DoubleCheckedLocking()
    {
        for (var i = 0; i < 50; i++)
        {
            new Thread(() => SampleSingleton.Create()).Start();
            new Thread(() => SampleSingleton.CreateThreadSafe()).Start();
        }
    }
}

public class SampleSingleton
{
    private static SampleSingleton? _instance, _threadSafeInstance;
    private static readonly object LockObject = new();

    private SampleSingleton(bool isSafe = false)
    {
        Console.WriteLine($"Sample singleton created. IsSafe: {isSafe}");
    }

    public static SampleSingleton Create()
    {
        if (_instance == null)
            _instance = new SampleSingleton();

        return _instance;
    }

    public static SampleSingleton CreateThreadSafe()
    {
        if (_threadSafeInstance == null)
        {
            lock (LockObject)
            {
                if (_threadSafeInstance == null)
                    _threadSafeInstance = new SampleSingleton(true);
            }
        }

        return _threadSafeInstance;
    }
}