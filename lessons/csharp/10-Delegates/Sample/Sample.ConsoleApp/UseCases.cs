namespace Sample.ConsoleApp;

public static class UseCases
{
    public static void Do()
    {
        HandleException(MethodThrowException, onException: (exception) => Thread.Sleep(1000));

        var filteredNumbers = new[] { 1, 2, 3, 4, 5 }.Filter(f => f > 2);
        var filteredStrings = new[] { "ahmet", "mehmet", "ayşe" }.Filter(f => f.StartsWith("a"));
    }

    static void MethodThrowException()
    {
        throw new Exception("Internal server error");
    }

    static void HandleException(Action action, int tryCount = 3, Action<Exception>? onException = null)
    {
        execute:
        try
        {
            Console.WriteLine("Çalıştırılıyor...");
            action();
        }
        catch (Exception e)
        {
            tryCount--;
            if (tryCount <= 0)
            {
                Console.WriteLine(e);
                return;
            }

            onException?.Invoke(e);
            goto execute;
        }
    }

    static IEnumerable<T> Filter<T>(this IEnumerable<T> items, Func<T, bool> predicate)
    {
        foreach (var item in items)
        {
            if (predicate(item))
                yield return item;
        }
    }
}