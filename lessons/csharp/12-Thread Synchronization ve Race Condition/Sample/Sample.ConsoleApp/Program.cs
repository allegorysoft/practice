//InterlockedExample();
//RaceConditionProblem();
//LockAndMonitor();

Console.ReadKey();

void InterlockedExample()
{
    var number = 0;
    var interlockedNumber = 0;

    ThreadStart work = () =>
    {
        for (var i = 0; i < 1_000_000; i++)
        {
            number++;
            Interlocked.Increment(ref interlockedNumber); //Decrement, Add, Exchange
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

void RaceConditionProblem()
{
    var money = 100;
    ParameterizedThreadStart work = m =>
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

void LockAndMonitor()
{
    var money = 100;
    var lockObject = new object();
    ParameterizedThreadStart work = async m =>
    {
        var expense = (int)m!;
        lock (lockObject)
        {
            //Critical section
            if (money >= expense)
            {
                Thread.Sleep(1000); //await Task.Delay(1000); !!!
                money -= expense;
            }
            else
            {
                Console.WriteLine("Expense payment denied.");
            }
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