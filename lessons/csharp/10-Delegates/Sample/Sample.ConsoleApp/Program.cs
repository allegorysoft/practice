using BenchmarkDotNet.Running;
using Sample.ConsoleApp;

//new Example().Do();
//UseCases.Do();
BenchmarkRunner.Run<DelegateBenchmark>();

Console.ReadKey();
