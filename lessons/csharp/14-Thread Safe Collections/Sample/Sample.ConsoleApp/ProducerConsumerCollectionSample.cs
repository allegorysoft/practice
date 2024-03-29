﻿using System.Collections.Concurrent;

namespace Sample.ConsoleApp;

public static class ProducerConsumerCollectionSample
{
    public static void Do()
    {
        //ConcurrentBagSample();
        //ConcurrentQueueSample();
        //ConcurrentStackSample();
        //BlockingCollectionSample();
        ProducerConsumerSample();
    }

    private static void ConcurrentBagSample()
    {
        var concurrentBag = new ConcurrentBag<int>();
        const int producedLength = 100_000;

        var producers = new Thread[Environment.ProcessorCount];
        for (var i = 0; i < producers.Length; i++)
        {
            producers[i] = new Thread(() =>
            {
                for (var j = 0; j < producedLength; j++)
                    concurrentBag.Add(j);
            });
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

    private static void ConcurrentQueueSample()
    {
        var concurrentQueue = new ConcurrentQueue<int>();
        const int producedLength = 100_000;

        var producers = new Thread[Environment.ProcessorCount];
        for (var i = 0; i < producers.Length; i++)
        {
            producers[i] = new Thread(() =>
            {
                for (var j = 0; j < producedLength; j++)
                    concurrentQueue.Enqueue(j);
            });
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

    private static void ConcurrentStackSample()
    {
        var concurrentStack = new ConcurrentStack<int>();
        const int producedLength = 100_000;

        var producers = new Thread[Environment.ProcessorCount];
        for (var i = 0; i < producers.Length; i++)
        {
            producers[i] = new Thread(() =>
            {
                for (var j = 0; j < producedLength; j++)
                    concurrentStack.Push(j);
            });
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

    private static void BlockingCollectionSample()
    {
        var blockingCollection = new BlockingCollection<int>(1);
        blockingCollection.Add(1);
        var item1 = blockingCollection.Take();

        //blockingCollection[0] Indexer doesn't work
        foreach (var item in blockingCollection)
            Console.WriteLine(item);
        blockingCollection.Add(100);
        var isAdd = blockingCollection.TryAdd(100);
        var takeItem = blockingCollection.Take();
        var isTake = blockingCollection.TryTake(out var blockingCollectionItem);
        //BlockingCollection<int>.AddToAny()
        //BlockingCollection<int>.TakeFromAny()
    }

    private static void ProducerConsumerSample()
    {
        var blockingCollection = new BlockingCollection<int>(1);

        var producer = new Thread(() =>
        {
            for (var i = 0; i < 10; i++)
                blockingCollection.Add(i);

            blockingCollection.CompleteAdding();
        });

        ThreadStart consumerWork = () =>
        {
            foreach (var item in blockingCollection.GetConsumingEnumerable())
            {
                Console.WriteLine(Thread.CurrentThread.Name + ": " + item);
                Thread.Sleep(Random.Shared.Next(500, 1500));
            }
        };
        var consumer1 = new Thread(consumerWork) { Name = "Consumer1" };
        var consumer2 = new Thread(consumerWork) { Name = "Consumer2" };

        producer.Start();
        consumer1.Start();
        consumer2.Start();
        producer.Join();
        consumer1.Join();
        consumer2.Join();
    }
}