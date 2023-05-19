using System.Collections.Concurrent;

BlockingCollectionSample();
Console.ReadKey();

void BlockingCollectionSample()
{
    var collection = new BlockingCollection<int>(1);
    new Thread(() =>
    {
        for (int i = 0; i < 10; i++)
        {
            collection.Add(i);
            Console.WriteLine("Added: " + i);
        }
    }).Start();

    new Thread(() =>
    {
        while (collection.TryTake(out int item, Timeout.Infinite))
        {
            Console.WriteLine("Consumed: " + item);
            Console.ReadKey();
        }
    }).Start();
}

void ConcurrentDictionarySample()
{
    var dictionary = new ConcurrentDictionary<string, int>();

    //dictionary.
}