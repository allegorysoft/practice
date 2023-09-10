using Sample.ConsoleApp;

//ListSample();
//ProducerConsumerCollectionSample.Do();
ConcurrentDictionarySample.Do();
return;

void ListSample()
{
    var list = new List<int>();
    const int producedLength = 100_000;

    var producers = new Thread[Environment.ProcessorCount];
    for (var i = 0; i < producers.Length; i++)
    {
        producers[i] = new Thread(() =>
        {
            for (var j = 0; j < producedLength; j++)
                list.Add(j);
        });
    }

    Array.ForEach(producers, p => p.Start());
    Array.ForEach(producers, p => p.Join());

    Console.WriteLine($"List item:{list.Count} Expected:{producedLength * Environment.ProcessorCount}");
}