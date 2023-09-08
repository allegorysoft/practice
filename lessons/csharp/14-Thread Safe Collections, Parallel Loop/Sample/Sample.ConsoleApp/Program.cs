using System.Collections.Concurrent;

//ListSample();
ConcurrentBagSample();
//BlockingCollectionSample();

return;

void ListSample()
{
    var list = new List<int>();
    const int producedLength = 100_000;
    ThreadStart producerWork = () =>
    {
        for (var i = 0; i < producedLength; i++)
            list.Add(i);
    };

    var producers = new Thread[Environment.ProcessorCount];
    for (var i = 0; i < producers.Length; i++)
    {
        producers[i] = new Thread(producerWork);
    }

    Array.ForEach(producers, p => p.Start());
    Array.ForEach(producers, p => p.Join());

    Console.WriteLine($"List item:{list.Count} Expected:{producedLength * Environment.ProcessorCount}");
}

void ConcurrentBagSample()
{
    var concurrentBag = new ConcurrentBag<int>();
    const int producedLength = 100_000;
    ThreadStart producerWork = () =>
    {
        for (var i = 0; i < producedLength; i++)
            concurrentBag.Add(i);
    };

    var producers = new Thread[Environment.ProcessorCount];
    for (var i = 0; i < producers.Length; i++)
    {
        producers[i] = new Thread(producerWork);
    }

    Array.ForEach(producers, p => p.Start());
    Array.ForEach(producers, p => p.Join());

    Console.WriteLine(
        $"Concurrent Bag item:{concurrentBag.Count} Expected:{producedLength * Environment.ProcessorCount}");

    //concurrentBag[0] Indexer doesn't work
    foreach (var item in concurrentBag)
        Console.WriteLine(item);
    concurrentBag.Add(100);
    var isTaken = concurrentBag.TryTake(out var takeItem);
    var isPeeked = concurrentBag.TryPeek(out var peekItem);
    concurrentBag.Clear();
}

void BlockingCollectionSample()
{
    var blockingCollection = new BlockingCollection<int>(1);

    new Thread(() =>
    {
        for (var i = 0; i < 10; i++)
        {
            blockingCollection.Add(i);
            Console.WriteLine("Added: " + i);
        }
    }).Start();

    new Thread(() =>
    {
        while (blockingCollection.TryTake(out var item, Timeout.Infinite))
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