
using System.Runtime.InteropServices;

namespace Sample.StackVsHeap.PointerTopic;

internal class PointerSample
{
    //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/unsafe-code
    //https://learn.microsoft.com/en-us/dotnet/api/system.intptr
    public static void Do()
    {
        PointerSize();
        MethodParameterConvention();
        Example();
    }

    static void PointerSize()
    {
        var pointerSize = IntPtr.Size;
        object o = new object();
        var list = new List<object>();

        for (int i = 0; i < 100_000_000; i++)
        {
            list.Add(o);
        }

        Console.ReadKey();
    }

    unsafe static void MethodParameterConvention()
    {
        int number = 10;
        int* pointer = &number;
        TakeNumber(pointer);
    }
    unsafe static void TakeNumber(int* pointer)
    {
        *pointer = 20;
    }

    unsafe static void Example()
    {
        var pointer = Marshal.AllocHGlobal(sizeof(int) * 5);
        int* numberPointer = (int*)pointer.ToPointer();

        for (int i = 0; i < 5; i++)
        {
            *(numberPointer + i) = i * 2;
        }

        Marshal.FreeHGlobal(pointer);
    }
}
