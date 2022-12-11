using System.Runtime.InteropServices;

namespace Sample.StackVsHeap.HeapTopic;

internal class HeapSizeLimit
{
    public static void Do()
    {
        const int size = 1024 * 1024;//1mb

        for (int i = 0; i < 1024 * 3; i++)
        {
            Marshal.AllocHGlobal(size);
        }
    }
}
