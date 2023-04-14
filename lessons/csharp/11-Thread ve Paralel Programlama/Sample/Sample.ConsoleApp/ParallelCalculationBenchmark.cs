using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;

namespace Sample.ConsoleApp;

[MemoryDiagnoser]
[Config(typeof(Config))]
public class ParallelCalculationBenchmark
{
    [Params(1_000_000, 10_000_000, 100_000_000)]
    public int Number { get; set; }

    [Benchmark(Baseline = true)]
    public void SingleThread()
    {
        var sum = new double[10];
        for (int i = 0; i < 10; i++)
        {
            sum[i] = ExponentialSum(i + 2);
        }
    }

    [Benchmark]
    public void MultiThread()
    {
        var threads = new Thread[10];
        var sum = new double[10];
        for (int i = 0; i < 10; i++)
        {
            var index = i;
            var exponent = index + 2;
            threads[index] = new Thread(() => { sum[index] = ExponentialSum(exponent); });
            threads[index].Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }
    }

    double ExponentialSum(int exponent)
    {
        double total = 0;
        for (int i = 0; i < Number; i++)
        {
            total += Math.Pow(i, exponent);
        }

        return total;
    }

    private class Config : ManualConfig
    {
        public Config()
        {
            SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend);
        }
    }
}