namespace Sample.StackVsHeap.StringTopic;

internal class StringSample
{
    public static void Do()
    {
        string number = string.Empty;
        for (int i = 0; i < 3; i++)
        {
            number += " " + i;
        }
    }
}
