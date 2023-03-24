using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;

namespace Sample.ConsoleApp;

[MemoryDiagnoser]
public class SpanBenchmark
{
    private readonly string _invoiceNumber = "INV2023032400001";
    private readonly List<IntWrapper> _numbers = IntWrapper.Create(100).ToList();

    [Benchmark]
    public void GetDateWithLinq()
    {
        int year = int.Parse(_invoiceNumber.Substring(3, 4));
        int month = int.Parse(_invoiceNumber.Substring(7, 2));
        int day = int.Parse(_invoiceNumber.Substring(9, 2));
        DateOnly date = new DateOnly(year, month, day);
    }

    [Benchmark]
    public void GetDateWithSpan()
    {
        ReadOnlySpan<char> span = _invoiceNumber;

        int year = int.Parse(span.Slice(3, 4));
        int month = int.Parse(span.Slice(7, 2));
        int day = int.Parse(span.Slice(9, 2));
        DateOnly date = new DateOnly(year, month, day);
    }

    [Benchmark]
    public void LoopForeach()
    {
        foreach (var number in _numbers)
        {

        }
    }

    [Benchmark]
    public void LoopSpan()
    {
        Span<IntWrapper> span = CollectionsMarshal.AsSpan(_numbers);
        foreach (var number in span)
        {

        }
    }
}