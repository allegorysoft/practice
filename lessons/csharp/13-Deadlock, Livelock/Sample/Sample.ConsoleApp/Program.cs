using Sample.ConsoleApp;

DeadLockSample();
//SemaphoreSample();
//Example.Do();
Console.ReadKey();

void DeadLockSample()
{
    var ahmet = new Person();
    var mehmet = new Person();

    var t1 = new Thread(() => ahmet.TransferDeadLock(100, mehmet));
    var t2 = new Thread(() => mehmet.TransferDeadLock(100, ahmet));
    t1.Start();
    t2.Start();
    t1.Join();
    t2.Join();

    Console.WriteLine("Aktarım tamamlandı");
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