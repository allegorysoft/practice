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