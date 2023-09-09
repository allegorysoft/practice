using System.Collections.Concurrent;

//ListSample();
//ConcurrentBagSample();
//ConcurrentQueueSample();
//ConcurrentStackSample();
BlockingCollectionSample();

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
    var isTake = concurrentBag.TryTake(out var takeItem);
    var isPeek = concurrentBag.TryPeek(out var peekItem);
    concurrentBag.Clear();
}

void ConcurrentQueueSample()
{
    var concurrentQueue = new ConcurrentQueue<int>();
    const int producedLength = 100_000;
    ThreadStart producerWork = () =>
    {
        for (var i = 0; i < producedLength; i++)
            concurrentQueue.Enqueue(i);
    };

    var producers = new Thread[Environment.ProcessorCount];
    for (var i = 0; i < producers.Length; i++)
    {
        producers[i] = new Thread(producerWork);
    }

    Array.ForEach(producers, p => p.Start());
    Array.ForEach(producers, p => p.Join());

    Console.WriteLine(
        $"Concurrent Queue item:{concurrentQueue.Count} Expected:{producedLength * Environment.ProcessorCount}");

    //concurrentQueue[0] Indexer doesn't work
    foreach (var item in concurrentQueue)
        Console.WriteLine(item);
    concurrentQueue.Enqueue(100);
    var isDequeue = concurrentQueue.TryDequeue(out var dequeueItem);
    var isPeek = concurrentQueue.TryPeek(out var peekItem);
    concurrentQueue.Clear();
}

void ConcurrentStackSample()
{
    var concurrentStack = new ConcurrentStack<int>();
    const int producedLength = 100_000;
    ThreadStart producerWork = () =>
    {
        for (var i = 0; i < producedLength; i++)
            concurrentStack.Push(i);
    };

    var producers = new Thread[Environment.ProcessorCount];
    for (var i = 0; i < producers.Length; i++)
    {
        producers[i] = new Thread(producerWork);
    }

    Array.ForEach(producers, p => p.Start());
    Array.ForEach(producers, p => p.Join());

    Console.WriteLine(
        $"Concurrent Stack item:{concurrentStack.Count} Expected:{producedLength * Environment.ProcessorCount}");

    //concurrentStack[0] Indexer doesn't work
    foreach (var item in concurrentStack)
        Console.WriteLine(item);
    concurrentStack.Push(100);
    var isPop = concurrentStack.TryPop(out var popItem);
    var isPeek = concurrentStack.TryPeek(out var peekItem);
    concurrentStack.Clear();
}

void BlockingCollectionSample()
{
    var blockingCollection = new BlockingCollection<int>(1);
    blockingCollection.Add(1);
    var item1 = blockingCollection.Take();

    var producer = new Thread(() =>
    {
        for (var i = 0; i < 10; i++)
            blockingCollection.Add(i);

        blockingCollection.CompleteAdding();
    });
    var consumer = new Thread(() =>
    {
        foreach (var item in blockingCollection.GetConsumingEnumerable())
        {
            Console.WriteLine("Consumed: " + item);
            Thread.Sleep(1000);
        }
    });
    producer.Start();
    consumer.Start();
    producer.Join();
    consumer.Join();

    //blockingCollection[0] Indexer doesn't work
    foreach (var item in blockingCollection)
        Console.WriteLine(item);
    blockingCollection.Add(100);
    var isAdd = blockingCollection.TryAdd(100);
    var takeItem = blockingCollection.Take();
    var isTake = blockingCollection.TryTake(out var blockingCollectionItem);
}

void ConcurrentDictionarySample()
{
    var dictionary = new ConcurrentDictionary<string, int>();

    //dictionary.
}