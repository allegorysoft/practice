using Sample.ConsoleApp;

DeadLockSample();
Example.Do();
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

