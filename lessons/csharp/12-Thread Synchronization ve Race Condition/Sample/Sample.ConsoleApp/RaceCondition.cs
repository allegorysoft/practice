namespace Sample.ConsoleApp;

public static class RaceCondition
{
    private static int _money = 100;

    public static void Do()
    {
        var t1 = new Thread(() => TryPayment(75));
        var t2 = new Thread(() => TryPayment(75));

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine(_money);
    }

    private static void TryPayment(int expense)
    {
        if (_money >= expense)
        {
            Thread.Sleep(1000);
            _money -= expense;
        }
        else
        {
            Console.WriteLine("Expense payment denied.");
        }
    }
}