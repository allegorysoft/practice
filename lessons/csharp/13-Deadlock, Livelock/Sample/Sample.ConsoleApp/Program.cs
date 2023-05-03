using Sample.ConsoleApp;

//DeadLockSample();
//SemaphoreSample();
//Example.Do();
LiveLockSample();
Console.ReadKey();

void DeadLockSample()
{
    var ahmet = new Person("Ahmet");
    var mehmet = new Person("Mehmet");

    var t1 = new Thread(() => ahmet.Transfer(100, mehmet));
    var t2 = new Thread(() => mehmet.Transfer(100, ahmet));
    t1.Start();
    t2.Start();
    t1.Join();
    t2.Join();

    Console.WriteLine("Transaction completed");
}

void LiveLockSample()
{
    var ahmet = new Person("Ahmet");
    var mehmet = new Person("Mehmet");

    var t1 = new Thread(() => ahmet.TransferLiveLock(100, mehmet));
    var t2 = new Thread(() => mehmet.TransferLiveLock(100, ahmet));
    t1.Start();
    t2.Start();
    t1.Join();
    t2.Join();

    Console.WriteLine("Transaction completed");
}

void SemaphoreSample()
{
    var semaphore = new SemaphoreSlim(1, 1);

    var action1 = async () =>
    {
        try
        {
            await semaphore.WaitAsync();
            Console.WriteLine("Action 1 working");
        }
        finally
        {
            semaphore.Release();
        }
    };

    var action2 = async () =>
    {
        try
        {
            await semaphore.WaitAsync();
            await action1();
            Console.WriteLine("Action 2 working");
        }
        finally
        {
            semaphore.Release();
        }
    };

    action2();
}