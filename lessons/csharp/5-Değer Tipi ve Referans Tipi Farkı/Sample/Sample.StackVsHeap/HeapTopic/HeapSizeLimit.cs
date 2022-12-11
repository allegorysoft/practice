using System.Runtime.InteropServices;

namespace Sample.StackVsHeap.HeapTopic;

internal class HeapSizeLimit
{
    public static void Do()
    {
        const int size = 1024 * 1024;//1mb

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 1024; j++)
            {
                Marshal.AllocHGlobal(size);
            }
        }
    }
}
