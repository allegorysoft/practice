namespace Sample.ConsoleApp;

public class IntWrapper
{
    public int Number { get; set; }

    public IntWrapper(int number)
    {
        Number = number;
    }

    public static IEnumerable<IntWrapper> Create(int count) =>
        Enumerable.Range(1, count).Select(x => new IntWrapper(x));
}