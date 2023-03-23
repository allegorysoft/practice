using BenchmarkDotNet.Running;
using Sample.ConsoleApp;

//SpanDefinitions.Do();
BenchmarkRunner.Run<SpanBenchmark>();

Console.ReadKey();