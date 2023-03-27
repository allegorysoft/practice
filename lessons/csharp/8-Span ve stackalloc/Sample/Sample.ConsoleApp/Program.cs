using BenchmarkDotNet.Running;
using Sample.ConsoleApp;
using System.Runtime.InteropServices;

CreateSpan();
ValueTypeBehaviour();
ReferenceTypeBehaviour();
StringBehaviour();
LoopBehaviour();
//BenchmarkRunner.Run<SpanBenchmark>();

Console.ReadKey();


static void CreateSpan()
{
    byte[] array = new byte[] { 1, 2, 3, 4, 5 };
    Span<byte> arraySpan = array;
    //var arraySpan =  new Span<byte>(array, 1, 2);
    //var arraySpan = array.AsSpan(1, 2);
    Span<byte> arraySpan2 = arraySpan.Slice(1, 2);
    arraySpan.Fill(5);
    arraySpan.Clear();

    Span<byte> stackSpan = stackalloc byte[] { 1, 2, 3, 4, 5 };
}

static void ValueTypeBehaviour()
{
    int[] array = Enumerable.Range(1, 5).ToArray();
    int[] array2 = array[1..3];
    array2[0] = 500;
    Console.WriteLine("İlk dizi: {0}, İkinci dizi: {1}", array[1], array2[0]);

    int[] arraySpan = Enumerable.Range(1, 5).ToArray();
    Span<int> arraySpan2 = arraySpan.AsSpan()[1..3]; //Diğer yöntem: arraySpan.AsSpan(1,2);
    arraySpan2[0] = 500;
    Console.WriteLine("İlk dizi: {0}, İkinci dizi: {1}", arraySpan[1], arraySpan2[0]);
}

static void ReferenceTypeBehaviour()
{
    IntWrapper[] array = IntWrapper.Create(5).ToArray();
    IntWrapper[] array2 = array[1..3];
    array2[0] = new IntWrapper(500);
    Console.WriteLine("İlk dizi: {0}, İkinci dizi: {1}", array[1].Number, array2[0].Number);

    IntWrapper[] arraySpan = IntWrapper.Create(5).ToArray();
    Span<IntWrapper> arraySpan2 = arraySpan.AsSpan()[1..3]; //Diğer yöntem: arraySpan.AsSpan(1,2);
    arraySpan2[0] = new IntWrapper(500);
    Console.WriteLine("İlk dizi: {0}, İkinci dizi: {1}", arraySpan[1].Number, arraySpan2[0].Number);
}

static void StringBehaviour()
{
    string numbers = "INV2023032400001";
    ReadOnlySpan<char> span = numbers;

    int year = int.Parse(span.Slice(3, 4));
    int month = int.Parse(span.Slice(7, 2));
    int day = int.Parse(span.Slice(9, 2));
    DateOnly date = new DateOnly(year, month, day);
}

static void LoopBehaviour()
{
    List<IntWrapper> numbers = IntWrapper.Create(5).ToList();
    Span<IntWrapper> span = CollectionsMarshal.AsSpan(numbers);
    numbers.Add(new IntWrapper(500));//Span içinde gözükmeyecektir
    foreach (var number in span)
    {
        Console.WriteLine(number.Number);
    }
}