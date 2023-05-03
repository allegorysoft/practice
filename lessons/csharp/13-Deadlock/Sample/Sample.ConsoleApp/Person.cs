namespace Sample.ConsoleApp;

public class Person
{
    private static int _counter;

    public int Id { get; }
    public int Balance { get; protected set; } = 500;

    public Person()
    {
        Id = Interlocked.Increment(ref _counter);
    }

    public void TransferDeadLock(int amount, Person to)
    {
        lock (this)
        {
            Thread.Sleep(1000);
            lock (to)
            {
                Balance -= amount;
                to.Balance += amount;
            }
        }
    }

    public void TransferLiveLock(int amount, Person to)
    {
        lock (this)
        {
            Thread.Sleep(1000);
            try
            {
                while (!Monitor.TryEnter(to))
                    Thread.Sleep(1000);

                Balance -= amount;
                to.Balance += amount;
            }
            finally
            {
                Monitor.Exit(to);
            }
        }
    }

    public void Transfer(int amount, Person to)
    {
        object lockObject1 = Id > to.Id ? this : to;
        object lockObject2 = lockObject1 == this ? to : this;

        lock (lockObject1)
        {
            Thread.Sleep(1000);
            lock (lockObject2)
            {
                Balance -= amount;
                to.Balance += amount;
            }
        }
    }
}