namespace Sample.ConsoleApp;

public class LockAndMonitor
{
    private static int _money = 100;
    private static readonly object LockObject = new object();

    public static void Do()
    {
        WithLock();
        WithMonitor();
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
}