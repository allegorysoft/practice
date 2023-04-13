using BenchmarkDotNet.Running;
using Sample.ConsoleApp;

//Create();
//BackgroundThread();
BenchmarkRunner.Run<ParallelCalculationBenchmark>();


void Create()
{
    var thread = new Thread(() =>
    {
        Console.WriteLine("Başladı");
        Method1();
        Thread.Sleep(10000);
        Console.WriteLine("Bitti");
    });

    thread.Name = "T-1";
    thread.Priority = ThreadPriority.Normal;

    Console.WriteLine($"IsAlive: {thread.IsAlive} State: {thread.ThreadState}");
    thread.Start();
    Console.WriteLine($"IsAlive: {thread.IsAlive} State: {thread.ThreadState}");

    OtherJob();

    thread.Join();
    Console.WriteLine($"IsAlive: {thread.IsAlive} State: {thread.ThreadState}");
}

void OtherJob() => Thread.Sleep(5000);
void Method1() => Method2();
void Method2() => Method3();

void Method3()
{
}

void BackgroundThread()
{
    var thread = new Thread((delay) =>
    {
        var t = Thread.CurrentThread;
        Console.WriteLine($"{t.Name} başladı id: {t.ManagedThreadId}");
        Thread.Sleep((int)delay);
        Console.WriteLine($"{t.Name} bitti id: {t.ManagedThreadId}");
    });
    thread.Name = "BG-1";
    //thread.IsBackground = true;

    thread.Start(10000);
}
