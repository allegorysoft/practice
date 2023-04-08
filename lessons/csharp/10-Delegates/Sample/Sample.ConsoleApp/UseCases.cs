namespace Sample.ConsoleApp;

public class UseCases
{
    public static void Do()
    {
        HandleException(MethodThrowException, onException: (exception) => Thread.Sleep(1000));
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

}