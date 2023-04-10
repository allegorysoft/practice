using BenchmarkDotNet.Attributes;

namespace Sample.ConsoleApp;

[MemoryDiagnoser]
public class DelegateBenchmark
{
    [Benchmark]
    public void DirectInvoke()
    {
        Method();
    }

    [Benchmark]
    public void DelegateInvoke()
    {
        Action action = Method;
        action();
    }

    [Benchmark]
    public void DirectAssign()
    {
        Action action = StaticMethod;
        action();
    }

    [Benchmark]
    public void NewAssign()
    {
        Action action = new Action(StaticMethod);
        action();
    }

    [Benchmark]
    public void WithoutClosure()
    {
        Action<int> action = i =>
        {
            i++;
        };
        action(0);
    }

    [Benchmark]
    public void Closure()
    {
        int i = 0;
        Action action = () =>
        {
            i++;
        };
        action();
    }

    void Method()
    {
        var total = 0;
        for (int i = 0; i < 1000; i++)
        {
            total += i;
        }
    }

    static void StaticMethod()
    {

    }
}