using System.Collections.Concurrent;

BlockingCollectionSample();
Console.ReadKey();

void BlockingCollectionSample()
{
    var collection = new BlockingCollection<int>(1);
    new Thread(() =>
    {
        for (int i = 0; i < 20; i++)
        {
            collection.Add(i);
            Console.WriteLine($"Producer Added: {i}");
        }
    }).Start();

    new Thread(() =>
    {
        while (collection.TryTake(out var item, Timeout.Infinite))
        {
            Console.WriteLine($"Consumer Start: {item}");
            Thread.Sleep(5_000);
            Console.WriteLine($"Consumer End: {item}");
        }
    }).Start();
}