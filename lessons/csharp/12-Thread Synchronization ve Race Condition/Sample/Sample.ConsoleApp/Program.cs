Problem();

Console.ReadKey();

void Problem()
{
    var money = 100;
    ParameterizedThreadStart work = (object? m) =>
    {
        var expense = (int)m!;
        if (money >= expense)
        {
            Thread.Sleep(1000);
            money -= expense;
        }
        else
        {
            Console.WriteLine("Expense payment denied.");
        }
    };

    var t1 = new Thread(work);
    var t2 = new Thread(work);
    t1.Start(75);
    t2.Start(75);
    t1.Join();
    t2.Join();

    Console.WriteLine(money);
}

