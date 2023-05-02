namespace Sample.ConsoleApp;

public class Example
{
    public static void Do()
    {
        var example = new Example();
        lock (example)
        {
            var t = new Thread(example.Job1);
            t.Start();
            t.Join();
        }
    }

    public void Job1()
    {
        lock (this)
        {
            Console.WriteLine("Doing");
        }
    }
}