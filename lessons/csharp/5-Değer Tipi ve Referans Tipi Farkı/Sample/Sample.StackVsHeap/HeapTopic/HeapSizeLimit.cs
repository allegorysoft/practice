using System.Runtime.InteropServices;

namespace Sample.StackVsHeap.HeapTopic;

internal class HeapSizeLimit
{
    public static void Do()
    {
        var ptr = Marshal.AllocHGlobal(1024 * 1024 * 1024);//1gb heapte yer tut
        Marshal.FreeHGlobal(ptr);//Pointer alanını boşa çek
    }
}
