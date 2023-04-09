namespace Sample.ConsoleApp;

delegate void BasicDelegate();

public delegate int Calculate(int n1, int n2);

public class Example
{
    public void Do()
    {
        Create();
        CombineDelegates();
        LambdaExpressions();
        ActionFunc();
        Closures();
    }

    void Create()
    {
        BasicDelegate delegate1 = Foo;
        BasicDelegate delegate2 = new BasicDelegate(Goo);
        Calculate delegate3 = Add;

        delegate1();
        delegate1();
        delegate2();
        var total = delegate3(5, 10);

        Zoo(delegate1);
        Zoo(delegate2);

        var delegate1Method = delegate1.Method;
        var delegate1Target = delegate1.Target;
        var delegate2Method = delegate2.Method;
        var delegate2Target = delegate2.Target;
    }

    void CombineDelegates()
    {
        BasicDelegate delegate1 = Foo;
        //delegate1 = (BasicDelegate)Delegate.Combine(delegate1, new BasicDelegate(Goo));
        delegate1 += Goo;
        delegate1 += Foo;

        delegate1();

        delegate1 -= Foo;
        delegate1();

        foreach (BasicDelegate basicDelegate in delegate1.GetInvocationList())
        {
            basicDelegate();
            Console.WriteLine($"Target: {basicDelegate.Target} Method: {basicDelegate.Method}");
        }
    }

    void LambdaExpressions()
    {
        BasicDelegate delegate1 = delegate { Console.WriteLine("Anonymous method"); };
        BasicDelegate delegate2 = () => Console.WriteLine("Lambda expression");

        void localFunction()
        {
            Console.WriteLine("Local function");
        }

        Calculate add = (int x, int y) =>
        {
            Console.WriteLine("Adding...");
            return x + y;
        };

        Zoo(() => { Console.WriteLine("Zoo called with lambda expression"); });
        Zoo(localFunction);
    }

    void ActionFunc()
    {
        Action action = Foo;
        action += () => { Console.WriteLine("Lambda method"); };
        action();

        Func<int> func = () => 10;
        Console.WriteLine(func());
    }

    void Closures()
    {
        int i = 0;
        Action a = () => i++;
        i++;
        a();
        Console.WriteLine(i);
    }

    void Foo()
    {
        Console.WriteLine("Foo");
    }

    static void Goo()
    {
        Console.WriteLine("Goo");
    }

    void Zoo(BasicDelegate basicDelegate)
    {
        basicDelegate();
    }

    int Add(int number1, int number2)
    {
        return number1 + number2;
    }
}