using System.Collections.Concurrent;

namespace Sample.ConsoleApp;

public static class ConcurrentDictionarySample
{
    public static void Do()
    {
        //Usage();
        ParallelGetOrAddCall();
    }

    private static void Usage()
    {
        var concurrentDictionary = new ConcurrentDictionary<string, int>();

        foreach (var item in concurrentDictionary)
            Console.WriteLine(item.Value);
        var isAdd = concurrentDictionary.TryAdd("key", 1);
        var isUpdate = concurrentDictionary.TryUpdate("key", 2, 1);
        var isGet = concurrentDictionary.TryGetValue("key", out var getItem);
        var isRemove = concurrentDictionary.TryRemove("key", out _);
        concurrentDictionary["k"] = 10;
        concurrentDictionary.AddOrUpdate("k", key => 1, (key, oldValue) => 2);
        var getItem2 = concurrentDictionary.GetOrAdd("k", key => 3);
        concurrentDictionary.Clear();
    }

    private static void ParallelGetOrAddCall()
    {
        var concurrentDictionary = new ConcurrentDictionary<string, Sample>();
        var semaphoreSlim = new SemaphoreSlim(0);
        var trigger = semaphoreSlim.WaitAsync();
        var tasks = new List<Task>();

        var work = async () =>
        {
            await trigger;
            concurrentDictionary.GetOrAdd("key", k =>
            {
                Console.WriteLine("GetOrAdd executed");
                return new Sample(k);
            });
        };

        for (var i = 0; i < 100; i++)
        {
            tasks.Add(Task.Run(work));
        }

        semaphoreSlim.Release();
        Task.WaitAll(tasks.ToArray());

        if (concurrentDictionary.TryGetValue("key", out var sample))
            Console.WriteLine("Sample Id: " + sample.Id);
    }
}

public class Sample
{
    public Guid Id { get; } = Guid.NewGuid();

    public Sample(string key)
    {
        Console.WriteLine("Created with key:" + key + " Id: " + Id);
    }
}