using System.Diagnostics;

namespace Sample.ConsoleApp;

public static class CallStack
{
    public static void Do()
    {
        int doLocal = 15;
        Method1();
    }

    static void Method1()
    {
        int method1Local = 20;
        Method2();
    }

    static void Method2()
    {
        int method2Local = 30;
        Method3();
    }

    static void Method3()
    {
        var stackTrace = new StackTrace(true);
        foreach (var stackFrame in stackTrace.GetFrames())
        {
            var fileName = stackFrame.GetFileName();
            var lineNumber = stackFrame.GetFileLineNumber();
            var method = stackFrame.GetMethod();
        }
    }
}
